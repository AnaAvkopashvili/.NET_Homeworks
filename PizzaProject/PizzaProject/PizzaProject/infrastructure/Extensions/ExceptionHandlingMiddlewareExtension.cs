using PizzaRestaurant.API.infrastructure.Middleware;

namespace PizzaRestaurant.API.infrastructure.Extensions
{
    public static class ExceptionHandlingMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlerMiddlware>();
            return builder;
        }
    }
}
