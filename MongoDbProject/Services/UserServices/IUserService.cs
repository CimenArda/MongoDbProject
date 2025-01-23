using MongoDbProject.Entities;

namespace MongoDbProject.Services.UserServices
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByUsernameAsync(string username);
        Task<ApplicationUser> RegisterUserAsync(ApplicationUser user, string password);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    }
}
