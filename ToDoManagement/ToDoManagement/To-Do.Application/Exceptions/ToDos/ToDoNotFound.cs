namespace ToDoManagement.Application.Exceptions.ToDos
{
    public class ToDoNotFound : Exception
    {
        public string Code = "ToDo not found";
        public ToDoNotFound(string message) : base(message) { }

    }
}
