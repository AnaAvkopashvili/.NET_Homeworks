using PizzaRestaurant.API.infrastructure.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class PizzaRequestExample : IMultipleExamplesProvider<PizzaCreateModel>
    {
        public IEnumerable<SwaggerExample<PizzaCreateModel>> GetExamples()
        {
            yield return SwaggerExample.Create("person 1", new PizzaCreateModel
            {
                Name = "Peperoni",
                Price = 15.0m,
                Description = "Pepperoni pizza",
                CaloryCount = 500
            });

            yield return SwaggerExample.Create("person 2", new PizzaCreateModel
            {
                Name = "Cheesy",
                Price = 15.0m,
                Description = "Cheese pizza",
                CaloryCount = 450
            });
        }
    }
}
