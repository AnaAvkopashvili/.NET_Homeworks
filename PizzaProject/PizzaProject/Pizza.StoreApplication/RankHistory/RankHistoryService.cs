using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Repositories;

namespace PizzaRestaurant.Application.RankHistory
{
    public class RankHistoryService : IRankHistoryService
    {
        private readonly IRankHistoryRepository _repository;
        public RankHistoryService(IRankHistoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(CancellationToken cancellationToken, RankHistoryResponseModel rankHistory)
        {
            return await _repository.Create(cancellationToken, rankHistory);
        }

         public async Task<double> Get(CancellationToken cancellationToken, int pizzaId)
        {
            var result = await _repository.Get(cancellationToken, pizzaId);

            if (result == null)
                throw new RankHistoryNotFound(pizzaId.ToString());
            else
                return result;
        }

        public async Task<List<RankHistoryResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
    }
}