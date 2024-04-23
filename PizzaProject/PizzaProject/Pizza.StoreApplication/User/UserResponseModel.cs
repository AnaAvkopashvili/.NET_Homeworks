using PizzaRestaurant.Application.Address;
namespace PizzaRestaurant.Application.User
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<AddressResponseModel> Addresses { get; set; }
        public bool IsDeleted {  get; set; }
    }
}
