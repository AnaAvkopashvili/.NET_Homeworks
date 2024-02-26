namespace PizzaRestaurant.Application.Exceptions
{
    public class OrderNotFound : Exception
    {
        public string Code = "Address not Found";
        public OrderNotFound(string message) : base(message) { }
    }
}
