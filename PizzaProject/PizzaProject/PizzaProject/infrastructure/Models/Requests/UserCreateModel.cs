
namespace PizzaRestaurant.API.infrastructure.Models.Requests
{
    public class UserCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> AddressesDescription { get; set; }

    }
}
