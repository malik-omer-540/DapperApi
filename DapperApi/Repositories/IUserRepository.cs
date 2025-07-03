using DapperApi.Models;

namespace DapperApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<List<User>> GetCachedUsersAsync();
    }
}
