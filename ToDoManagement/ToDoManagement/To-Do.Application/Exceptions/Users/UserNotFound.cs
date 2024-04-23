namespace ToDoManagement.Application.Exceptions.Users
{
    public class UserNotFound : Exception
    {
        public string Code = "User not found";
        public UserNotFound(string message) : base(message) { }
    }
}
