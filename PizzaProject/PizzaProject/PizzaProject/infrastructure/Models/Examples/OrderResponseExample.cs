using PizzaRestaurant.Application.Order;
using PizzaRestaurant.Application.Pizza;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class OrderResponseExample : IExamplesProvider<OrderResponseModel>
    {
        public OrderResponseModel GetExamples()
        {
            return new OrderResponseModel
            {
                UserId = 2,
                AddressID = 2,
                Pizzas = new List<PizzaResponseModel> { new PizzaResponseModel { Id = 3, Name = "4 Cheese pizza", Description = "mozzarella, Parmesan, blue cheese, stracchino", Price = 20.0m, CaloryCount = 600, IsDeleted = false } }
            };
        }
    }
}
