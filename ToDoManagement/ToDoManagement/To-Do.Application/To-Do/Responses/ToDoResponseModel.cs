using To_Do.Application.Subtasks.Responses;
using To_Do.Domain.Entity;

namespace ToDoManagement.Application.To_Do
{
    public enum ToDoStatuses
    {
        Active = 1,
        Done = 2,
        Deleted = 3
    }
    public class ToDoResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ToDoStatuses Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public List<SubtaskResponseModel> subtasks { get; set; }
        public int OwnerId {  get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public EntityStatus EntityStat { get; set; }
    }

}
