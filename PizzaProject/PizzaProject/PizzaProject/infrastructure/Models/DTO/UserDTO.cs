namespace PizzaRestaurant.API.infrastructure.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string>? AddressesCity { get; set; }
        public bool IsDeleted {  get; set; }
    }
}
