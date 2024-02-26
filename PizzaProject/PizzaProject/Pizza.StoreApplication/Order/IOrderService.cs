namespace PizzaRestaurant.Application.Order
{
    public interface IOrderService
    {
        Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<OrderResponseModel> Get(CancellationToken cancellationToken, int Id);
        Task<bool> Create(CancellationToken cancellationToken, OrderResponseModel order);
    }
}
