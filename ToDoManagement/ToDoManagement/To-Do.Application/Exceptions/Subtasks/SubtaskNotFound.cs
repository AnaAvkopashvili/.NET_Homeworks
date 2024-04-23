namespace ToDoManagement.Application.Exceptions.Subtasks
{
    public class SubtaskNotFound : Exception
    {
        public string Code = "Subtask not found";
        public SubtaskNotFound(string message) : base(message) { }

    }
}
