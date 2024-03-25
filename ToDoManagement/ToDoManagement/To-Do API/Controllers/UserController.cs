using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ToDoManagement.Application.Users.Requests;
using ToDoManagement.Application.Users;
using ToDoManagement.Infrastructure.Auth.JWT;

namespace ToDoManagement.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<JWTConfiguration> _options;

        public UserController(IUserService userService, IOptions<JWTConfiguration> options)
        {
            _userService = userService;
            _options = options;
        }

        [Route("register")]
        [HttpPost]
        public async Task Register(UserCreateModel user, CancellationToken cancellation = default)
        {
             await _userService.CreateAsync(cancellation, user);
        }

        [Route("login")]
        [HttpPost]
        public async Task<string> LogIn(UserLoginModel user, CancellationToken cancellation = default)
        {
            var result = await _userService.AuthenticationAsync(cancellation, user.Username, user.PasswordHash);

            return JWTHelper.GenerateSecurityToken(result, _options);
        }
    }
}
