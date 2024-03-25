namespace ToDoManagement.Application.Exceptions.ToDos
{
    public class ToDoAlreadyExists : Exception
    {
        public string Code = "ToDo already exists";
        public ToDoAlreadyExists(string message) : base(message) { }

    }
}
