using Forum.Application.Accounts.Requests;
using Forum.Application.Accounts.Responses;
using Forum.Application.Comments.Responses;
using Forum.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Forum.Application.Accounts
{
    public interface IUserService
    {
        //Task<bool> LoginAsync(string email, string password);
        Task<LoginResult> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<IdentityResult> RegisterAsync(RegistrationRequestModel model);
        Task UpdateAsync(CancellationToken cancellationToken, UserPutModel model);
        Task<UserPutModel> GetAsync(CancellationToken cancellationToken, string id);
/*        Task RemovePropertiesAsync(CancellationToken cancellationToken, string userId);
*/
    }
}
