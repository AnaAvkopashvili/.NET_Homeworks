using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Repositories;

namespace PizzaRestaurant.Application.Address
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddressResponseModel> Get(CancellationToken cancellationToken, int Id)
        {
            var result = await _repository.Get(cancellationToken, Id);

            if (result == null)
                throw new AddressNotFound(Id.ToString());
            else
                return result;
        }

        public async Task<List<AddressResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task Create(CancellationToken cancellationToken, AddressRequestModel address)
        {
            await _repository.Create(cancellationToken, address);
        }

        public async Task Update(CancellationToken cancellationToken, AddressRequestModel address)
        {
            if (!await _repository.Exists(cancellationToken, address.Id))
                throw new AddressNotFound(address.Id.ToString());

            await _repository.Update(cancellationToken, address);
        }
        public async Task Delete(CancellationToken cancellationToken, int Id)
        {
            if (!await _repository.Exists(cancellationToken, Id))
                throw new AddressNotFound(Id.ToString());

            await _repository.Delete(cancellationToken, Id);
        }
    }
}
