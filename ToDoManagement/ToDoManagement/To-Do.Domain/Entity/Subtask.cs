using To_Do.Domain.Entity;

namespace ToDoManagement.Domain.Entity
{
    public class Subtask : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ToDoItemId { get; set; }
        public ToDo ToDoItem {  get; set; }
    }
}
    