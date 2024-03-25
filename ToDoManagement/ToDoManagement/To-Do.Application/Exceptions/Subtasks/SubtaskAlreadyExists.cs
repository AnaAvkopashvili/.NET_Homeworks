namespace ToDoManagement.Application.Exceptions.Subtasks
{
    public class SubtaskAlreadyExists : Exception
    {
        public string Code = "Subtask Already Exists";
        public SubtaskAlreadyExists(string message) : base(message) { }   

    }
}
