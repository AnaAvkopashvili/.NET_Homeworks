namespace PizzaRestaurant.Application.Exceptions
{
    public class PizzaAlreadyExists : Exception
    {
        public string Code = "Pizza Already Exists";

        public PizzaAlreadyExists(string message) : base(message) { }

    }
}
