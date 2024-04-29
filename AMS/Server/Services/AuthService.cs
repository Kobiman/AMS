using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
//using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AMS.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(ApplicationDbContext dbContext, 
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetStaffID() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber);
        public string GetLocationID() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Locality);

        public async Task<Result<string>> Login(string email, string password)
        {
            var userrolesNames = new List<string>();
            //throw new NotImplementedException();
            var response = new Result<string>();
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                response.IsSucessful = false;
                response.Message = "User not found!";
            }
            else if (!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt ))
            {
                response.IsSucessful = false;
                response.Message = "Wrong Password";
            }
            else
            {
                var userroles = await  _dbContext.UserRoles.Where(x => x.UserId == user.Id).ToListAsync();
                if (userroles.Any() )
                {
                    foreach ( var role in userroles )
                    {

                        var val = await _dbContext.Pages_Roles.FirstOrDefaultAsync(x => x.Id == role.RoleId);
                        if (val != null)
                            userrolesNames.Add(val.Name);  
                    }
                }

                //var userroles = await (from u in _dbContext.UserRoles.Where(x => x.UserId == user.Id)
                //                       join r in _dbContext.Pages_Roles on u.RoleId equals r.Id 
                //                       select new  { r.Name}).ToListAsync();
                response.IsSucessful = true;
                response.Value = CreateToken(user, userrolesNames);
                response.Message = "Login Successful";
            }
            return response;
                 
        }

        public async Task<Result<int>> Register(User user, string password)
        {
            if(await UserExists(user.Email))
            {
                return new Result<int> { IsSucessful = false, Message = "User Already Exists" };
            }
            CreatePasswordHash(password, out byte[] psswrdHash, out byte[] psswrdSalt);
            user.PasswordHash = psswrdHash;
            user.PasswordSalt = psswrdSalt;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return new Result<int> { IsSucessful = true, Value = user.Id, Message = "Registration Successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
           
            if(_dbContext.Users.Any(u => u.Email.ToLower()
            .Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user, List<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {                
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.SerialNumber, user.StaffId),
                new Claim(ClaimTypes.Locality, user.LocationId.ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                   claims: claims,
                   expires: DateTime.UtcNow.AddDays(1),
                   signingCredentials: creds                  
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<Result<bool>> ChangePassword(int userId, string password)
        {
            var user =  _dbContext.Users.Find(userId);
            if (user == null)
            {
                return new Result<bool> { IsSucessful = false, Message = "User not found" };
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _dbContext.SaveChangesAsync();

            return new Result<bool> { IsSucessful = true, Value = true,Message="Password has been changed" };

        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users =  _dbContext.Users.ToList();
            return users.Select(x => new UserDto { Id = x.Id, Email = x.Email, StaffId = x.StaffId,
                LocationId = Convert.ToInt32(x.LocationId) });
        }

        public async Task<Result<int>> DeleteUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if(user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return new Result<int> { IsSucessful = true, Message = "User Deleted Successfully", Value = userId };
            }
            return new Result<int> { IsSucessful = false, Message = "Operation Failed!", Value = userId };

        }
        
        public async Task<Result<UserDto>> EditUserRole(int userId, List<UserPageAccessDto> editUserDto,int locationId)
        {
            UserDto userDto = null;
            List<UserRoles> userRoles = new List<UserRoles>();
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                for(int i = 0; i < editUserDto.Count; i++)
                {
                    if(!await UserRoleExists(userId, editUserDto[i].RoleId) && editUserDto[i].IsSelected)
                    {
                        var usrRole = new UserRoles { RoleId = editUserDto[i].RoleId, UserId=userId };
                        await _dbContext.UserRoles.AddAsync(usrRole);
                    }
                    else if(await UserRoleExists(userId, editUserDto[i].RoleId) && !editUserDto[i].IsSelected)
                    {
                        var usrRole = await _dbContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == editUserDto[i].RoleId);
                        if(usrRole != null)
                        {
                            _dbContext.UserRoles.Remove(usrRole);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                user.LocationId = locationId;
                await _dbContext.SaveChangesAsync();
                userDto = new UserDto { Id= user.Id,Email=user.Email,LocationId=Convert.ToInt16(user.LocationId)};
                return new Result<UserDto> { IsSucessful = true, Message = "User Deleted Successfully", Value = userDto };
            }
            return new Result<UserDto> { IsSucessful = false, Message = "Operation Failed!", Value = userDto };
        }

        public async Task<IEnumerable<UserPageAccessDto>> GetUserPageAccess(int userId)
        {
            var userPageAccess = new List<UserPageAccessDto>();
            var roles = await _dbContext.Pages_Roles.ToListAsync();
            foreach (var role in roles) 
            {
                var userspages = new UserPageAccessDto();
                userspages.PageValueName = role.Name;
                userspages.PageDisplayName = role.DisplayName;
                userspages.RoleId = role.Id;
                if(_dbContext.UserRoles.Any(x => x.UserId == userId && x.RoleId == role.Id))
                {
                    userspages.IsSelected = true;
                }
                userPageAccess.Add(userspages);
            }
            return userPageAccess;
        }
        private async Task<bool> UserRoleExists(int userId, int roleId)
        {
            if (await _dbContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //public async Task<UserInfo> GetUserInfo()
        //{
        //    UserInfo userInfo = new UserInfo();
        //    int userId = Convert.ToInt16( _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        //    if(user != null)
        //    {
        //        userInfo.StaffId= user.StaffId;
        //        userInfo.Location = await _locationService.GetLocationById(Convert.ToInt16(user.LocationId));
        //    }
        //    return userInfo;
        //}
    }
}
