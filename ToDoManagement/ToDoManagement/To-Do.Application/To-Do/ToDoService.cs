using Mapster;
using To_Do.Application.To_Do.Requests;
using To_Do.Domain.Entity;
using ToDoManagement.Application.Exceptions.ToDos;
using ToDoManagement.Domain.Entity;

namespace ToDoManagement.Application.To_Do
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ToDoResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repository.GetAsync(cancellationToken, id);

            if (result == null || (ToDoStatuses)result.Status == ToDoStatuses.Deleted || result.EntityStat == EntityStatus.Deleted)
                throw new ToDoNotFound("ToDo with this ID: " + id.ToString() + " was not found!");
            else
                return result.Adapt<ToDoResponseModel>();
        }

        public async Task<List<ToDoResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            return result.Adapt<List<ToDoResponseModel>>(); 
        }

        public async Task CreateAsync(CancellationToken cancellationToken, ToDoRequestPostModel ToDo)
        {
            var ToInsert = ToDo.Adapt<ToDo>();
            await _repository.CreateAsync(cancellationToken, ToInsert);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, ToDoRequestPutModel ToDo)
        {
            if (!await _repository.Exists(cancellationToken, ToDo.Id))
                throw new ToDoNotFound("ToDo with this ID: " + ToDo.Id.ToString() + " was not found!");

            var existingToDo = await _repository.GetAsync(cancellationToken, ToDo.Id);
            existingToDo.Title = ToDo.Title;
            existingToDo.Status = (ToDo.ToDoStatuses)ToDo.Status;
            existingToDo.CompletionDate = ToDo.CompletionDate;

            existingToDo.ModifiedOn = DateTime.UtcNow;
            await _repository.UpdateAsync(cancellationToken, existingToDo);
        }

        public async Task PatchAsync(CancellationToken cancellationToken, int id, ToDoRequestPatchModel ToDo)
        {

            var ToUpdate = ToDo.Adapt<ToDo>();
            ToUpdate.ModifiedOn = DateTime.UtcNow;
            await _repository.PatchAsync(cancellationToken, ToUpdate, id);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (!await _repository.Exists(cancellationToken, id))
                throw new ToDoNotFound("ToDo with this ID: " + id.ToString() + " was not found!");

            await _repository.DeleteAsync(cancellationToken, id);   
        }
    }
}
