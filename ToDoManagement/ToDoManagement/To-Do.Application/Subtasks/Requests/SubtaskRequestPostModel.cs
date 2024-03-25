using ToDoManagement.Application.To_Do;

namespace To_Do.Application.Subtasks.Requests
{
    public class SubtaskRequestPostModel
    {
        public string Title { get; set; }
        public int ToDoItemId { get; set; }
    }
}
