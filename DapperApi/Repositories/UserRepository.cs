using Dapper;
using DapperApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DapperApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IMemoryCache _cache;

        public UserRepository(IDbConnectionFactory connectionFactory, IMemoryCache cache)
        {
            _connectionFactory = connectionFactory;
            _cache = cache;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Email = @Email", new { Email = email });
        }

        public async Task<List<User>> GetCachedUsersAsync()
        {
            if (_cache.TryGetValue("users", out List<User> cachedUsers))
            {
                return cachedUsers;
            }

            using var connection = _connectionFactory.CreateConnection();
            var users = (await connection.QueryAsync<User>("SELECT * FROM Users")).ToList();

            _cache.Set("users", users, TimeSpan.FromMinutes(10));
            return users;
        }
    }
}
