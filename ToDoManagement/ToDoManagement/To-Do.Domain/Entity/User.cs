using To_Do.Domain.Entity;

namespace ToDoManagement.Domain.Entity
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<ToDo> ToDos { get; set; }
    }
}
