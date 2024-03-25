using To_Do.Application.Subtasks.Requests;
using To_Do.Application.Subtasks.Responses;
using Mapster;
using ToDoManagement.Application.Exceptions.Subtasks;
using ToDoManagement.Domain.Entity;
using To_Do.Domain.Entity;

namespace ToDoManagement.Application.Subtasks
{
    public class SubtaskService : ISubtaskService
    {

        private readonly ISubtaskRepository _repository;
        public SubtaskService(ISubtaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubtaskResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var result = await _repository.GetAsync(cancellationToken, id);

            if (result == null || result.EntityStat.Equals(EntityStatus.Deleted))
                throw new SubtaskNotFound("Subtask with this ID: " + id.ToString() + " was not found!");
            else
                return result.Adapt<SubtaskResponseModel>();
        }

        public async Task<List<SubtaskResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            return result.Adapt<List<SubtaskResponseModel>>();
        }

        public async Task CreateAsync(CancellationToken cancellationToken, SubtaskRequestPostModel subtask)
        {
            var ToInsert = subtask.Adapt<Subtask>();
            await _repository.CreateAsync(cancellationToken, ToInsert);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, SubtaskRequestPutModel subtask)
        {
            if (!await _repository.Exists(cancellationToken, subtask.Id))
                throw new SubtaskNotFound("Subtask with this ID: " + subtask.Id.ToString() + " was not found!");

            var existingSubtask = await _repository.GetAsync(cancellationToken, subtask.Id);
            existingSubtask.Title = subtask.Title;

            // var ToUpdate = existingSubtask.Adapt<Subtask>();
            await _repository.UpdateAsync(cancellationToken, existingSubtask);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (!await _repository.Exists(cancellationToken, id))
                throw new SubtaskNotFound("Subtask with this ID: " + id.ToString() + " was not found!");

            await _repository.DeleteAsync(cancellationToken, id);
        }
    }
}
