using ToDoManagement.Application.To_Do;

namespace To_Do.Application.To_Do.Requests
{
    public class ToDoRequestPatchModel
    {
        public string? Title { get; set; }
        public ToDoStatuses? Status { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
