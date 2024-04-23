using Mapster;
using PizzaRestaurant.Application.Address;
using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Repositories;

namespace PizzaRestaurant.Infrastructure.Addresses
{
    public class AddressRepository : IAddressRepository
    {

        private static List<AddressResponseModel> _addresses = new List<AddressResponseModel>
        {
            new AddressResponseModel{Id = 1, UserId = 1, City = "Kutaisi", Country = "Georgia", Region = "Imereti", Description = "Axalgazrdobis mexute shesaxvevi", IsDeleted = false},
            new AddressResponseModel{Id = 2, UserId = 2,  City = "Kutaisi", Country = "Georgia", Region = "Imereti", Description = "Axalgazrdobis mexute shesaxvevi", IsDeleted = false}
        };

        public async Task<AddressResponseModel> Get(CancellationToken cancellationToken, int Id)
        {
            return await Task.FromResult(_addresses.SingleOrDefault(x => x.Id == Id && !x.IsDeleted));
        }

        public async Task<List<AddressResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_addresses);
        }

        public async Task Create(CancellationToken cancellationToken, AddressRequestModel address)
        {
            if (_addresses.Exists(x => x.Id == address.Id))
                throw new AddressAlreadyExists("Address already Exists");

            var result = address.Adapt<AddressResponseModel>();
            result.Id = _addresses.Max(x => x.Id) + 1;
            _addresses.Add(result);
        }

        public async Task Update(CancellationToken cancellationToken, AddressRequestModel address)
        {

            var existingAddress = await Get(cancellationToken, address.Id);
            if (existingAddress == null)
            {
                throw new AddressNotFound("this address was not found");
            }
            existingAddress.UserId = address.UserId;
            existingAddress.City = address.City;
            existingAddress.Country = address.Country;
            existingAddress.Id = address.Id;
            existingAddress.Region = address.Region;
            existingAddress.Description = address.Description;
            existingAddress.IsDeleted = address.IsDeleted;

            address.Adapt<AddressResponseModel>();
        }
        public async Task Delete(CancellationToken cancellationToken, int Id)
        {
            var address = await Get(cancellationToken, Id);
            if (address == null)
            {
                throw new AddressNotFound("Address with this id was not found");
            }
            address.IsDeleted = true;
        }
        public Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var result = _addresses.Find(x => x.Id == id);
            return Task.FromResult(!(result == null));
        }
    }
}
