using Mapster;
using To_Do.Application.Subtasks.Requests;
using To_Do.Application.Subtasks.Responses;
using ToDoManagement.Application.To_Do;
using ToDoManagement.Application.Users.Requests;
using ToDoManagement.Domain.Entity;

namespace ToDoManagement.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<ToDo, ToDoResponseModel>.NewConfig().TwoWays();
            TypeAdapterConfig<Subtask, SubtaskResponseModel>.NewConfig().TwoWays();
            TypeAdapterConfig<ToDoRequestPutModel, ToDo>.NewConfig().TwoWays();
            TypeAdapterConfig<SubtaskRequestPutModel, Subtask>.NewConfig().TwoWays();
            TypeAdapterConfig<UserCreateModel, User>.NewConfig().TwoWays();
        }
    }
}
