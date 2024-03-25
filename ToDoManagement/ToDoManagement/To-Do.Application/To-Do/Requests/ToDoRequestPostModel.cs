using To_Do.Application.Subtasks.Requests;

namespace ToDoManagement.Application.To_Do
{
    public class ToDoRequestPostModel
    {
        public string Title { get; set; }
        public ToDoStatuses Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public List<SubtaskRequestPostModel> subtasks { get; set; }
        public int OwnerId { get; set; }
    }
}
