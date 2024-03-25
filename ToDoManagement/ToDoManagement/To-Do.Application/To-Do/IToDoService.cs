using To_Do.Application.To_Do.Requests;

namespace ToDoManagement.Application.To_Do
{
    public interface IToDoService
    {
        Task<List<ToDoResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ToDoResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, ToDoRequestPostModel ToDo);
        Task UpdateAsync(CancellationToken cancellationToken, ToDoRequestPutModel ToDo);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task PatchAsync(CancellationToken cancellationToken, int id, ToDoRequestPatchModel ToDo);
    }
}
