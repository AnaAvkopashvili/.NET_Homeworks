using PizzaRestaurant.Application.User;

namespace PizzaRestaurant.Application.Repositories
{
    public interface IUserRepository
    {
        Task<UserResponseModel> Get(CancellationToken cancellationToken, int Id);
        Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken);
        Task Create(CancellationToken cancellationToken, UserRequestModel user);
        Task Update(CancellationToken cancellationToken, UserRequestModel user);
        Task Delete(CancellationToken cancellationToken, int Id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);

    }
}
