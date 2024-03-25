using PersonManagement.Infrastructure.Users;
using ToDoManagement.Application.Subtasks;
using ToDoManagement.Application.To_Do;
using ToDoManagement.Application.Users;
using ToDoManagement.Infrastructure.Subtasks;
using ToDoManagement.Infrastructure.ToDos;

namespace ToDoManagement.Infrastructure.Extentions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISubtaskService, SubtaskService>();
            services.AddScoped<ISubtaskRepository, SubtaskRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
        }
    }
}
