namespace PizzaRestaurant.Application.Exceptions
{
    public class AddressAlreadyExists : Exception
    {
        public string Code = "Address alreasy exists";

        public AddressAlreadyExists(string message) : base(message) { }

    }
}
