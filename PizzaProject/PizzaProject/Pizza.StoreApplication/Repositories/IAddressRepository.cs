using PizzaRestaurant.Application.Address;

namespace PizzaRestaurant.Application.Repositories
{
    public interface IAddressRepository
    {
        Task<List<AddressResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<AddressResponseModel> Get(CancellationToken cancellationToken, int Id);
        Task Create(CancellationToken cancellationToken, AddressRequestModel address);
        Task Update(CancellationToken cancellationToken, AddressRequestModel address);
        Task Delete(CancellationToken cancellationToken, int Id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);

    }
}
