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

        public AuthService(ApplicationDbContext dbContext, IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetStaffID() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber);

        public async Task<Result<string>> Login(string email, string password)
        {
            //throw new NotImplementedException();
            var response = new Result<string>();
            var user = _dbContext.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
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
                response.IsSucessful = true;
                response.Value = CreateToken(user);
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
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.SerialNumber, user.StaffId)
            };
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
            return users.Select(x => new UserDto { Id = x.Id, Email = x.Email, Role = x.Role,StaffId = x.StaffId });
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

        public async Task<Result<UserDto>> EditUserRole(int userId, string role)
        {
            UserDto userDto = null;
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                user.Role = role;
                await _dbContext.SaveChangesAsync();
                userDto = new UserDto { Id= user.Id,Email=user.Email,Role=user.Role};
                return new Result<UserDto> { IsSucessful = true, Message = "User Deleted Successfully", Value = userDto };
            }
            return new Result<UserDto> { IsSucessful = false, Message = "Operation Failed!", Value = userDto };
        }
    }
}
