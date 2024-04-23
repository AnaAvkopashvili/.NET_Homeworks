using Forum.Application.Accounts.Requests;
using Forum.Application.Accounts.Responses;
using Forum.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers 
{
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpGet]
        public async Task<List<UserManagementResponseModel>> GetAll()
        {
            return await _userManagementService.GetAllAsync();
        }

        [HttpGet("{userId}")]
        public async Task<List<ManageUserRolesResponseModel>> Get(string userId)
        {
            return await _userManagementService.GetAsync(userId);
        }

        [HttpPut("{userId}")]
        public async Task ManageUserRoles(string userId, [FromBody] List<ManageUserRolesRequestModel> model)
        {
            await _userManagementService.ManageUserRolesAsync(model, userId);
        }
    }
}