using Microsoft.EntityFrameworkCore;
using To_Do.Domain.Entity;
using To_Do.Infrastructure;
using ToDoManagement.Application.Exceptions.ToDos;
using ToDoManagement.Application.To_Do;
using ToDoManagement.Domain.Entity;
using ToDoManagement.Persitsence.Context;

namespace ToDoManagement.Infrastructure.ToDos
{
    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoManagementContext context) : base(context)
        { }

        public async Task<ToDo?> GetAsync(CancellationToken cancellationToken, int id)
        {
            var todo = await _dbSet
                .Include(t => t.subtasks) 
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            return todo;
        }

        public async Task<List<ToDo>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _dbSet.Include(t => t.subtasks).ToListAsync(cancellationToken);
            return result;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, ToDo todo)
        {
            await base.CreateAsync(cancellationToken, todo);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, ToDo todo)
        {
            await base.UpdateAsync(cancellationToken, todo);
        }
        public async Task PatchAsync(CancellationToken cancellationToken, ToDo toDo, int id)
        {
            await base.PatchAsync(cancellationToken, id, toDo);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var todo = await base.GetAsync(cancellationToken, id);
            if (todo == null)
            {
                throw new ToDoNotFound("ToDo was not Found");
            }
            todo.EntityStat = EntityStatus.Deleted;
            todo.Status = ToDo.ToDoStatuses.Deleted;
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await base.AnyAsync(cancellationToken, x => x.Id == id);    
        }
    }
}
