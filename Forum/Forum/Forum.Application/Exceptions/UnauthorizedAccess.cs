namespace Forum.Application.Exceptions
{
    public class UnauthorizedAccess : Exception
    {
        public string Code = "Access Denied! Please Login with valid credentials!";
        public UnauthorizedAccess(string message) : base(message) { }

    }
}
