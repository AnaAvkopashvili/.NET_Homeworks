using PizzaRestaurant.Application.Address;
using PizzaRestaurant.Application.Order;
using PizzaRestaurant.Application.Pizza;
using PizzaRestaurant.Application.RankHistory;
using PizzaRestaurant.Application.Repositories;
using PizzaRestaurant.Application.User;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Infrastructure.Orders;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.RankHistories;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.API.infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRankHistoryService, RankHistoryService>();
            services.AddScoped<IRankHistoryRepository, RankHistoryRepository>();

        }
    }
}
