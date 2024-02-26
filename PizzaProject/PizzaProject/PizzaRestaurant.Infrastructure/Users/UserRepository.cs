using Mapster;
using PizzaRestaurant.Application.Address;
using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Repositories;
using PizzaRestaurant.Application.User;

namespace PizzaRestaurant.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {

        private static List<UserResponseModel> _users = new List<UserResponseModel>
        {
            new UserResponseModel{Id = 1, FirstName = "Ana", LastName = "Avkopashvili", Email = "AnaAvkopashvili@gmail.com",
                PhoneNumber = "555555555", Addresses =  new List<AddressResponseModel> {new AddressResponseModel { Id = 1, UserId = 1, City = "Kutaisi", Country = "Georgia", Region = "Imereti", Description = "Axalgazedobis mexute shesaxvei"} }, IsDeleted = false },

             new UserResponseModel{Id = 2, FirstName = "Nino", LastName = "Avkopashvili", Email = "NinoAvkopashvili@gmail.com",
                PhoneNumber = "555111111", Addresses =  new List<AddressResponseModel> {new AddressResponseModel { Id = 2, UserId = 2, City = "Kutaisi", Country = "Georgia", Region = "Imereti", Description = "dadianis qucha" } }, IsDeleted = false }

        };
        public async Task<UserResponseModel> Get(CancellationToken cancellationToken, int Id)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Id == Id && !x.IsDeleted));
        }
          
        public async Task<List<UserResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_users);
        }
        public async Task Create(CancellationToken cancellationToken, UserRequestModel user)
        {
            if (_users.Exists(x => x.Id == user.Id))
            {
                throw new UserAlreadyExists("this user already exists");
            }
            var result = user.Adapt<UserResponseModel>();
            result.Id = _users.Max(x => x.Id) + 1;
            _users.Add(result);
        }
        public async Task Update(CancellationToken cancellationToken, UserRequestModel user)
        {
            var existingUser = await Get(cancellationToken, user.Id);
            if (existingUser == null)
            {
                throw new UserNotFound("this user was not found");
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Id = user.Id;
            existingUser.PhoneNumber = user.PhoneNumber;

            user.Adapt<UserResponseModel>();
        }

        public async Task Delete(CancellationToken cancellationToken, int Id)
        {
            var result = await Get(cancellationToken, Id);
            if (result == null)
            {
                throw new UserNotFound("this user was not found");
            }
            result.IsDeleted = true;
        }

        public Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var result =  _users.Find(x => x.Id == id);
            return Task.FromResult(!(result == null));
        }
        public static bool ExistsInDataBase(int userId)
        {
            return _users.Any(user => user.Id == userId && !user.IsDeleted);
        }
        public static bool ValidateAddress(int addressId, int useId)
        {
            var UserAddresses= _users.Find(x => x.Id == useId).Addresses;
            return UserAddresses.Any(x => x.Id == addressId);
        }
    }
}
