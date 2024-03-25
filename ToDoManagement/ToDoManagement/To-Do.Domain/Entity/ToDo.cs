using To_Do.Domain.Entity;

namespace ToDoManagement.Domain.Entity
{
    public class ToDo : BaseEntity
    {
        public enum ToDoStatuses
        {
            Active = 1,
            Done = 2,
            Deleted = 3
        }
        public int Id {  get; set; }
        public string Title { get; set; }
        public ToDoStatuses Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int OwnerId { get; set; }
        public List<Subtask> subtasks { get; set; }
        public User Owner { get; set; }
    }
}
