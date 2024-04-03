namespace AMS.Server.Services
{
    public interface IAuthService
    {
        Task<Result<int>> Register(User user, string password);
        Task<bool> UserExists(string email);
        Task<Result<string>> Login(string email, string password);
        Task<Result<bool>> ChangePassword(int userId, string password);

        Task<IEnumerable<UserDto>> GetUsers();
        Task<Result<int>> DeleteUser(int userId);

        Task<Result<UserDto>> EditUserRole(int userId,List<UserPageAccessDto> editUserDtos,int locationId);

        Task<IEnumerable<UserPageAccessDto>> GetUserPageAccess(int userId);

        string GetStaffID();
        string GetLocationID();

    }
}
