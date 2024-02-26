namespace PizzaRestaurant.Application.Exceptions
{
    public class UserAlreadyExists : Exception
    {
        public string Code = "User Already Exists";

        public UserAlreadyExists(string message) : base(message) { }
    }
}
