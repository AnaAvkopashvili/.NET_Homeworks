using PizzaRestaurant.Application.Pizza;

namespace PizzaRestaurant.API.infrastructure.Models.Requests
{
    public class OrderCreateModel
    {
        public int UserId { get; set; }
        public int AddressID { get; set; }
        public List<PizzaResponseModel> Pizzas { get; set; }
    }
}
