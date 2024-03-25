using Mapster;
using ToDoManagement.Application.Exceptions.Users;
using ToDoManagement.Application.Users.Requests;
using ToDoManagement.Domain.Entity;

namespace ToDoManagement.Application.Users
{
    public class UserService : IUserService
     {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> AuthenticationAsync(CancellationToken cancellationToken, string username, string password)
        {
            var result = await _repository.GetAsync(cancellationToken, username, password);

            if (result == null)
                throw new Exception("username or password is incorrect");

            return result.Username;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, UserCreateModel userModel)
        {
            var exists = await _repository.Exists(cancellationToken, userModel.Username);

            if (exists)
                throw new UserAlreadyExists("user already exists");

            var user = userModel.Adapt<User>();
            await _repository.CreateAsync(cancellationToken, user);
        }
    }
}
