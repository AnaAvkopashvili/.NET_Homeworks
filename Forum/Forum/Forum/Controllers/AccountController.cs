using Forum.API.Infrastructure.JWT;
using Forum.Application.Accounts;
using Forum.Application.Accounts.Requests;
using Forum.Application.Exceptions;
using Forum.Application.Exceptions.Users;
using Forum.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserManagementService _userRoleService;
        private readonly IOptions<JWTConfiguration> _options;

        public AccountController(IUserService userService, IOptions<JWTConfiguration> options, IUserManagementService userRoleService)
        {
            _userService = userService;
            _options = options;
            _userRoleService = userRoleService;
        }

        [HttpPost("register")]
        public async Task Register(RegistrationRequestModel user, CancellationToken cancellationToken)
        {
            var result = await _userService.RegisterAsync(user);
            if (!result.Succeeded)
            {
                throw new UserAlreadyExists("Registration failed, user with this Email or Username already exists!");
            }
        }

        [HttpPost("login")]
        public async Task<string> LogIn(LoginRequestModel user, CancellationToken cancellationToken)
        {
            var result = await _userService.LoginAsync(user.Email, user.Password);
            if (result.Succeeded)
            {
                var roles = await _userRoleService.GetUserRolesAsync(user.Email);

                return JWTHelper.GenerateSecurityToken(user.Email, roles, _options);
            }
            throw new UnauthorizedAccess(result.ErrorMessage);

        }
        [HttpPost("logout")]
        public async Task Logout()
        {
            await _userService.LogoutAsync();
        }
        [Authorize(Policy = "UserOnly")]
        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, UserPutModel user)
        {
            await _userService.UpdateAsync(cancellationToken, user);
        }
    }
}
