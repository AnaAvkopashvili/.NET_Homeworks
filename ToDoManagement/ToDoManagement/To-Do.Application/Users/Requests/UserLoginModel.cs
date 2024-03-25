namespace ToDoManagement.Application.Users.Requests
{
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
