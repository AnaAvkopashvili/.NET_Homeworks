using System.ComponentModel.DataAnnotations;

namespace Forum.Application.Accounts.Requests
{
    public class UserPutModel
    {
        public string Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }

        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
