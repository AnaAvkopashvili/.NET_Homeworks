using PizzaRestaurant.API.infrastructure.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class UserRequestExample : IMultipleExamplesProvider<UserCreateModel>
    {
        public IEnumerable<SwaggerExample<UserCreateModel>> GetExamples()
        {
        yield return SwaggerExample.Create("person 1", new UserCreateModel
            {
                FirstName = "Tatia",
                LastName = "Shengelia",
                Email = "tatiashengelia@gmail.com",
                PhoneNumber = "555555555",
                AddressesDescription = new List<string> { "address1" }
        });

            yield return SwaggerExample.Create("person 2", new UserCreateModel
            {
                FirstName = "Tako",
                LastName = "Sirbiladze",
                Email = "ako.sirbiladze@gmail.com",
                PhoneNumber = "555555555",
                 AddressesDescription = new List<string> { "address2", "address3" }
            });
        }
    }
}
