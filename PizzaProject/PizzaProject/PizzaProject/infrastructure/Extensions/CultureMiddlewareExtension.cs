using PizzaRestaurant.API.infrastructure.Middleware;

namespace PizzaRestaurant.API.infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CultureMiddleware>();
            return builder;
        }
    }
}
