using Forum.Application.Accounts.Requests;
using Forum.Application.Accounts.Responses;
using Forum.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Forum.Application.Services
{
    public class UserManagementService : IUserManagementService
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public UserManagementService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<List<UserManagementResponseModel>> GetAllAsync()
            {
                var users = await _userManager.Users.ToListAsync();
                var userRoles = users.Adapt<List<UserManagementResponseModel>>();

                foreach (var userRole in userRoles)
                {
                    var user = await _userManager.FindByIdAsync(userRole.Id);
                    userRole.Roles = new List<string>(await _userManager.GetRolesAsync(user));
                }

                return userRoles;
            }

            /* public async Task<List<ManageUserRolesResponseModel>> GetAsync(string userId)
             {
                 var user = await _userManager.FindByIdAsync(userId);
                 var model = new List<ManageUserRolesResponseModel>();

                 foreach (var role in _roleManager.Roles)
                 {
                     var userRolesViewModel = new ManageUserRolesResponseModel
                     {
                         RoleId = role.Id,
                         RoleName = role.Name
                     };

                     if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
                     {
                         userRolesViewModel.Selected = true;
                     }
                     else
                     {
                         userRolesViewModel.Selected = false;
                     }

                     model.Add(userRolesViewModel);
                 }

                 return model;
             }*/
            public async Task<List<ManageUserRolesResponseModel>> GetAsync(string userId)
            {
                var user = await _userManager.FindByIdAsync(userId);
                var model = new List<ManageUserRolesResponseModel>();

                if (user != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var normalizedUserRoles = await _roleManager.Roles
                        .Where(r => userRoles.Contains(r.Name))
                        .Select(r => r.NormalizedName)
                        .ToListAsync();

                    foreach (var role in _roleManager.Roles)
                    {
                        var userRolesViewModel = new ManageUserRolesResponseModel
                        {
                            RoleId = role.Id,
                            RoleName = role.Name,
                            Selected = normalizedUserRoles.Contains(role.NormalizedName)
                        };

                        model.Add(userRolesViewModel);
                    }
                }
                else
                {
                    foreach (var role in _roleManager.Roles)
                    {
                        var userRolesViewModel = new ManageUserRolesResponseModel
                        {
                            RoleId = role.Id,
                            RoleName = role.Name,
                            Selected = false
                        };

                        model.Add(userRolesViewModel);
                    }
                }

                return model;
            }

            public async Task ManageUserRolesAsync(List<ManageUserRolesRequestModel> model, string userId)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return;
                }

                var roles = new List<string>(await _userManager.GetRolesAsync(user));

                var result = await _userManager.RemoveFromRolesAsync(user, roles);

                if (result.Succeeded)
                {
                    result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
                }
            }

            public async Task<bool> IsUserInRole(ClaimsPrincipal user, string role)
            {
                var currentUser = await _userManager.GetUserAsync(user);
                return await _userManager.IsInRoleAsync(currentUser, role);
            }
            public async Task<IEnumerable<string>> GetUserRolesAsync(string email)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    throw new Exception($"User with email {email} not found.");
                }

                var roles = await _userManager.GetRolesAsync(user);
                return roles;
            }
            public async Task BanUserAsync(string id)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    throw new Exception($"User with id {id} not found.");
                }

                user.BanExpiration = DateTime.UtcNow.Add(TimeSpan.FromSeconds(120));
                await _userManager.UpdateAsync(user);
            }
            public async Task UnbanUserAsync(string id)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    throw new Exception($"User with id {id} not found.");
                }

                user.BanExpiration = null;
                await _userManager.UpdateAsync(user);
            }

            public async Task<List<UserManagementResponseModel>> GetAllBannedAsync()
            {
                 var users = await _userManager.Users.Where(u => u.BanExpiration.HasValue && u.BanExpiration.Value < DateTime.UtcNow).ToListAsync();
                 return  users.Adapt<List<UserManagementResponseModel>>();

            }
    }
}