using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.RankHistory;
using PizzaRestaurant.Application.Repositories;
using PizzaRestaurant.Infrastructure.Orders;

namespace PizzaRestaurant.Infrastructure.RankHistories
{
    public class RankHistoryRepository : IRankHistoryRepository
    {
        private static List<RankHistoryResponseModel> _rankHistory = new List<RankHistoryResponseModel>
        {
            new RankHistoryResponseModel() {UserId = 1, PizzaId = 1, Rank = 10},
            new RankHistoryResponseModel() {UserId = 2, PizzaId = 2, Rank = 9}
        };

        public async Task<bool> Create(CancellationToken cancellationToken, RankHistoryResponseModel rankHistory)
        {
            if (_rankHistory.Exists(x => x.UserId == rankHistory.UserId && x.PizzaId == rankHistory.PizzaId))
            {
                throw new RankHistoryAlreadyExists("rank already Exists");
            }
            if(OrderRepository.OrderExists(rankHistory.UserId, rankHistory.PizzaId)  
                && rankHistory.Rank <= 10 && rankHistory.Rank >= 0)
            {
                _rankHistory.Add(rankHistory);
                return true;
            }
            return false;
        }

        public Task<bool> Exists(CancellationToken cancellationToken, int pizzaId)
        {
            var result = _rankHistory.Find(x => x.PizzaId == pizzaId);
            return Task.FromResult(!(result == null));
        }

        public async Task<double> Get(CancellationToken cancellationToken, int pizzaId)
        {
            var ranks = _rankHistory.Where(x => x.PizzaId == pizzaId).Select(x => x.Rank).ToList();

            if (ranks.Any())
            {
                return await Task.FromResult(ranks.Average());
            }
            else
            {
                return await Task.FromResult(-1);
            }
        }

        public async Task<List<RankHistoryResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_rankHistory);
        }
    }
}
