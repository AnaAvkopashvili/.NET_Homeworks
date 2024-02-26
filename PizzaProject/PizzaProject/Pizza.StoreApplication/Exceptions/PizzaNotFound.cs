namespace PizzaRestaurant.Application.Exceptions
{
    public class PizzaNotFound : Exception
    {
        public string Code = "Pizza was Not Found";

        public PizzaNotFound(string message) : base(message) { }

    }
}
