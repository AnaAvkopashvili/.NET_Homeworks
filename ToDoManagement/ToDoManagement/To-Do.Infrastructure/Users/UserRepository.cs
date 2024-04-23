using Microsoft.EntityFrameworkCore;
using To_Do.Infrastructure;
using ToDoManagement.Application.Users;
using ToDoManagement.Domain.Entity;
using ToDoManagement.Persitsence.Context;

namespace PersonManagement.Infrastructure.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ToDoManagementContext context) : base(context)
        { }
        public async Task<User> GetAsync(CancellationToken cancellationToken, string username, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password, cancellationToken);

        }
        public async Task CreateAsync(CancellationToken cancellationToken, User user)
        {
            await base.CreateAsync(cancellationToken, user);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, string username)
        {
            return await base.AnyAsync(cancellationToken, x => x.Username == username);
        }
    }
}
