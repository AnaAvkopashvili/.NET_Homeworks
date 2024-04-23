using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Repositories;

namespace PizzaRestaurant.Application.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(CancellationToken cancellationToken, OrderResponseModel order)
        {
            return await _repository.Create(cancellationToken, order);
        }

        public async Task<OrderResponseModel> Get(CancellationToken cancellationToken, int Id)
        {
            var result = await _repository.Get(cancellationToken, Id);

            if (result == null)
                throw new OrderNotFound(Id.ToString());
            else
                return result;
        }

        public async Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
    }
}
