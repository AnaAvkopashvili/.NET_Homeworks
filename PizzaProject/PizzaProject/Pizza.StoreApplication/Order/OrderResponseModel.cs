using PizzaRestaurant.Application.Pizza;

namespace PizzaRestaurant.Application.Order
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressID { get; set; }
        public List<PizzaResponseModel> Pizzas { get; set; }
    }
}
