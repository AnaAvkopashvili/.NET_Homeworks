using System;
using ToDoManagement.Domain.Entity;

namespace ToDoManagement.Application.To_Do
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> GetAllAsync(CancellationToken cancellationToken);
        Task<ToDo> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, ToDo toDo);
        Task UpdateAsync(CancellationToken cancellationToken, ToDo toDo);
        Task PatchAsync(CancellationToken cancellationToken, ToDo toDo, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
    }
}
