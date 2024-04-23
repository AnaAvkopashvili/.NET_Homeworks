using PizzaRestaurant.API.infrastructure.Middleware;

namespace PizzaRestaurant.API.infrastructure.Extensions
{
    public static class RequestResponseLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestResponseLoggingMiddleware>();
            return builder;
        }
    }
}
