using ToDoManagement.Application.To_Do;

namespace ToDoManagement.Application.Users.Requests
{
    public class UserCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<ToDoRequestPostModel> ToDos { get; set; }
    }
}
