using PizzaRestaurant.API.infrastructure.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class AddressRequestExample : IExamplesProvider<AddressCreateModel>
    {
        public AddressCreateModel GetExamples()
        {

            return new AddressCreateModel
            {
                UserId = 2,
                City = "Kutaisi",
                Country = "Georgia",
                Region = "Imereti",
                Description = "Chavchavadze"
            };
        }
    }
}
