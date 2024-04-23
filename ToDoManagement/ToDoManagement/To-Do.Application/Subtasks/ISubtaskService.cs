using To_Do.Application.Subtasks.Requests;
using To_Do.Application.Subtasks.Responses;

namespace ToDoManagement.Application.Subtasks
{
    public interface ISubtaskService
    {
        Task<List<SubtaskResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<SubtaskResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, SubtaskRequestPostModel subtask);
        Task UpdateAsync(CancellationToken cancellationToken, SubtaskRequestPutModel subtask);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
    }
}
