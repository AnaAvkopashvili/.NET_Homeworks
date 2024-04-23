namespace ToDoManagement.Application.To_Do
{
    public class ToDoRequestPutModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ToDoStatuses Status { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
