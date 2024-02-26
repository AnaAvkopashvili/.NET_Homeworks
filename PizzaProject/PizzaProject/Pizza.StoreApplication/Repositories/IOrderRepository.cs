using PizzaRestaurant.Application.Order;

namespace PizzaRestaurant.Application.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<OrderResponseModel> Get(CancellationToken cancellationToken, int Id);
        Task<bool> Create(CancellationToken cancellationToken, OrderResponseModel order);
        Task<bool> Exists(CancellationToken cancellationToken, int id);

    }
}
