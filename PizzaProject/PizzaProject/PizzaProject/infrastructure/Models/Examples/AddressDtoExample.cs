using PizzaRestaurant.API.infrastructure.Models.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class AddressDtoExample : IExamplesProvider<AddressDTO>
    {
        public AddressDTO GetExamples()
        {

            return new AddressDTO
            {
                Id = 3,
                UserId = 1,
                City = "city",
                Country = "Country",
                Region = "region",
                Description = "Description",
                IsDeleted = false
            };
        }
    }
}
