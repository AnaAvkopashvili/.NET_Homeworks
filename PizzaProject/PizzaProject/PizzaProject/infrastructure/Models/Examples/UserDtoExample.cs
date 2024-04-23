using PizzaRestaurant.API.infrastructure.Models.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class UserDtoExample : IExamplesProvider<UserDTO>
    {
        public UserDTO GetExamples()
        {

            return new UserDTO
            {
                Id = 3,
                FirstName = "Nino",
                LastName = "Gogia",
                Email = "Nino.Gogia@gmail.com",
                PhoneNumber = "1234567890",
                AddressesCity = new List<string> { "Address4" },
                IsDeleted = false
            };
        }
    }
}
