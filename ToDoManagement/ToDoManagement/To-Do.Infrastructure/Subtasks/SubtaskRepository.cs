using To_Do.Domain.Entity;
using To_Do.Infrastructure;
using ToDoManagement.Application.Exceptions.Subtasks;
using ToDoManagement.Application.Subtasks;
using ToDoManagement.Domain.Entity;
using ToDoManagement.Persitsence.Context;

namespace ToDoManagement.Infrastructure.Subtasks
{
    public class SubtaskRepository : BaseRepository<Subtask>, ISubtaskRepository
    {
        public SubtaskRepository(ToDoManagementContext context) : base(context)
        { }

        public async Task<Subtask> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await base.GetAsync(cancellationToken, id);
        }

        public async Task<List<Subtask>> GetAllAsync(CancellationToken cancellationToken, int id)
        {
            return await base.GetAllAsync(cancellationToken);
        }
        public async Task CreateAsync(CancellationToken cancellationToken, Subtask subtask)
        {
            await base.CreateAsync(cancellationToken, subtask);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Subtask subtask)
        {
            await base.UpdateAsync(cancellationToken, subtask);   
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var subtask = await base.GetAsync(cancellationToken, id);
            if (subtask == null)
            {
                throw new SubtaskNotFound("ToDo was not Found");
            }
            subtask.EntityStat = EntityStatus.Deleted;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await base.AnyAsync(cancellationToken, x => x.Id == id);
        }
    }
}
