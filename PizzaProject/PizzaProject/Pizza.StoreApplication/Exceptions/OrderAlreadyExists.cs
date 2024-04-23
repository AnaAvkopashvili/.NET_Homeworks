namespace PizzaRestaurant.Application.Exceptions
{
    public class OrderAlreadyExists : Exception
    {
        public string Code = "order alreasy exists";

        public OrderAlreadyExists(string message) : base(message) { }

    }
}
