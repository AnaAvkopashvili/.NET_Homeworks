using To_Do.Domain.Entity;

namespace To_Do.Application.Subtasks.Responses
{
    public class SubtaskResponseModel
    {
        public int Id { get; set; }
        public int ToDoItemId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public EntityStatus EntityStat { get; set; }
    }
}
