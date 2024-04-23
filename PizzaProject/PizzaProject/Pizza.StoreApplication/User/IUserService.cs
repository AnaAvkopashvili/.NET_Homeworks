namespace PizzaRestaurant.Application.User
{
    public interface IUserService
    {
        Task<UserResponseModel> Get(CancellationToken cancellationToken, int Id);
        Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken);
        Task Create(CancellationToken cancellationToken, UserRequestModel user);
        Task Update(CancellationToken cancellationToken, UserRequestModel user);
        Task Delete(CancellationToken cancellationToken, int Id);
    }
}
