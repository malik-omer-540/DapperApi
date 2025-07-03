using DapperApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// ✅ Optimized Dapper query with parameterized SQL and indexed column (email)
        /// </summary>
        [HttpGet("by-email")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _repository.GetUserByEmailAsync(email);
            return user == null ? NotFound() : Ok(user);
        }

        /// <summary>
        /// ✅ Cached user list to avoid repetitive DB calls
        /// </summary>
        [HttpGet("cached")]
        public async Task<IActionResult> GetCachedUsers()
        {
            var users = await _repository.GetCachedUsersAsync();
            return Ok(users);
        }
    }
}
