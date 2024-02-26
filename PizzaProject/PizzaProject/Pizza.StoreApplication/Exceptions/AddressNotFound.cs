namespace PizzaRestaurant.Application.Exceptions
{
    public class AddressNotFound : Exception
    {
        public string Code = "Address not Found";
        public AddressNotFound(string message) : base(message) { }
    }
}
