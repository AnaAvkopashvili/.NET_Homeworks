using ToDoManagement.Infrastructure.Middlewares;

namespace ToDoManagement.Infrastructure.Extentions
{
    public static class GlobalExceptionHandlingExtentension 
    {
        public static IApplicationBuilder UseExceptionhandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            return builder;
        }
    }
}
