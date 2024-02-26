using PizzaRestaurant.API.infrastructure.Models.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class PizzaDtoExample : IExamplesProvider<PizzaDTO>
    {
        public PizzaDTO GetExamples()
        {
            return new PizzaDTO
            {
                Id = 4,
                Name = "Today's Special",
                Price = 20.0m,
                Description = "Chef's mystery pizza",
                CaloryCount = 600,
                IsDeleted = false
            };
        }
    }
}
