using ToDoManagement.Domain.Entity;

namespace ToDoManagement.Application.Users
{
    public interface IUserRepository
    {
        Task CreateAsync(CancellationToken cancellationToken, User user);
        Task<User> GetAsync(CancellationToken cancellationToken, string username, string password);
        Task<bool> Exists(CancellationToken cancellationToken, string username);
    }
}
