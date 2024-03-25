using To_Do.Domain.Entity;

namespace ToDoManagement.Application.Users.Responses
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public EntityStatus EntityStat { get; set; }
    }
}
