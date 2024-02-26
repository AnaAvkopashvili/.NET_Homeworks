using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Order;
using PizzaRestaurant.Application.Pizza;
using PizzaRestaurant.Application.Repositories;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private static List<OrderResponseModel> _orders = new List<OrderResponseModel>
        {
            new OrderResponseModel() {Id = 1, UserId = 1, AddressID = 1, Pizzas = new List<PizzaResponseModel>
            { new PizzaResponseModel { Id = 1, Name = "Peperoni Pizza", Description = " tomato sauce, mozzarella cheese, pepperoni sausage", Price = 20.0m, CaloryCount = 500, IsDeleted = false } }},
             new OrderResponseModel() {Id = 2, UserId = 2, AddressID = 2, Pizzas = new List<PizzaResponseModel>
             { new PizzaResponseModel {Id = 2, Name = "Margherita", Description = "tomato sauce, white mozzarella, basil", Price = 18.0m, CaloryCount = 400 , IsDeleted = false} } },
                new OrderResponseModel() {Id = 3, UserId = 1, AddressID = 1, Pizzas = new List<PizzaResponseModel>
             { new PizzaResponseModel {Id = 2, Name = "Margherita", Description = "tomato sauce, white mozzarella, basil", Price = 18.0m, CaloryCount = 400 , IsDeleted = false} } }
        };
        public async Task<bool> Create(CancellationToken cancellationToken, OrderResponseModel order)
        {
            List<int> pizzaIds = order.Pizzas.Select(pizza => pizza.Id).ToList();

            if (_orders.Exists(x => x.Id == order.Id))
                throw new OrderAlreadyExists("Order already Exists");
            if(UserRepository.ValidateAddress(order.AddressID, order.UserId)
               && PizzaRepository.ValidatePizzas(pizzaIds))
            {
                order.Id = _orders.Max(x => x.Id) + 1;
                _orders.Add(order);
                return true;
            }
            return false;
        }

        public Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var result = _orders.Find(x => x.Id == id);
            return Task.FromResult(!(result == null));
        }
        public async Task<OrderResponseModel> Get(CancellationToken cancellationToken, int Id)
        {
            return await Task.FromResult(_orders.SingleOrDefault(x => x.Id == Id));
        }

        public async Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_orders);
        }
        public static bool OrderExists(int useId, int pizzaId)
        {
            var UserOrders = _orders.FindAll(x => x.UserId == useId);
            return UserOrders.Any(x => x.Pizzas.Any(p => p.Id == pizzaId));
        }
    }
}
