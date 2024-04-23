namespace To_Do.Application.Subtasks.Requests
{
    public class SubtaskRequestPutModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ToDoItemId { get; set; }
    }
}
