using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.Application.Pizza;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class OrderRequestExample : IExamplesProvider<OrderCreateModel>
    {
        public OrderCreateModel GetExamples()
        {

            return new OrderCreateModel
            {
                UserId = 1,
                AddressID = 1,
                Pizzas = new List<PizzaResponseModel> {new PizzaResponseModel{Id = 3, Name = "4 Cheese pizza", Description = "mozzarella, Parmesan, blue cheese, stracchino", Price = 20.0m, CaloryCount = 600, IsDeleted = false  }}
            };
        }
    }
}
