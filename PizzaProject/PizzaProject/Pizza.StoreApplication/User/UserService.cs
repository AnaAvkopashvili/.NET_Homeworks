using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Repositories;

namespace PizzaRestaurant.Application.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository reposiotry)
        {
            _repository = reposiotry;
        }

        public async Task<UserResponseModel> Get(CancellationToken cancellationToken, int Id)
        {
            var result = await _repository.Get(cancellationToken, Id);

            if (result == null)
                throw new UserNotFound(Id.ToString());
            else
                return result;
        }

        public async Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
        public async Task Create(CancellationToken cancellationToken, UserRequestModel user)
        {
            await _repository.Create(cancellationToken, user); 
        }
        public async Task Update(CancellationToken cancellationToken, UserRequestModel user)
        {
            if (!await _repository.Exists(cancellationToken, user.Id))
                throw new UserNotFound(user.Id.ToString());

            await _repository.Update(cancellationToken, user);
        }

        public async Task Delete(CancellationToken cancellationToken, int Id)
        {
            if (!await _repository.Exists(cancellationToken, Id))
                throw new UserNotFound(Id.ToString());

            await _repository.Delete(cancellationToken, Id);
        }
    }
}
