using ToDoManagement.Application.Users.Requests;

namespace ToDoManagement.Application.Users
{
    public interface IUserService
    {
        Task<string> AuthenticationAsync(CancellationToken cancellationToken, string username, string password);
        Task CreateAsync(CancellationToken cancellationToken, UserCreateModel user);
    }
}
