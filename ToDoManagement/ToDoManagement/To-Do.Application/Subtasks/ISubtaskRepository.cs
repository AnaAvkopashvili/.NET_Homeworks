using ToDoManagement.Domain.Entity;

namespace ToDoManagement.Application.Subtasks
{
    public interface ISubtaskRepository
    {
        Task<List<Subtask>> GetAllAsync(CancellationToken cancellationToken);
        Task<Subtask> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Subtask subtask);
        Task UpdateAsync(CancellationToken cancellationToken, Subtask subtask);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
    }
}
