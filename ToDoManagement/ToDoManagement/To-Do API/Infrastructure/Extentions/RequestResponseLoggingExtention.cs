using ToDoManagement.Infrastructure.Middlewares;

namespace ToDoManagement.Infrastructure.Extentions
{
    public static class RequestResponseLoggingExtention
    {
       public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
       {
             builder.UseMiddleware<RequestResponseLoggingMiddleware>();
             return builder;
       }
       
    }
}
