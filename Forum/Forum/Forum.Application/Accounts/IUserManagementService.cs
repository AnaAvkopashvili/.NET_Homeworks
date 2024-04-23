using Forum.Application.Accounts.Requests;
using Forum.Application.Accounts.Responses;
using System.Security.Claims;

namespace Forum.Application.Services
{
    public interface IUserManagementService
    {
        Task<List<UserManagementResponseModel>> GetAllAsync();
        Task<List<ManageUserRolesResponseModel>> GetAsync(string userId);
        Task ManageUserRolesAsync(List<ManageUserRolesRequestModel> model, string userId);
        Task<bool> IsUserInRole(ClaimsPrincipal user, string role);
        Task<IEnumerable<string>> GetUserRolesAsync(string email);
        Task BanUserAsync(string userId);
        Task UnbanUserAsync(string userId);
        Task<List<UserManagementResponseModel>> GetAllBannedAsync();
    }
}