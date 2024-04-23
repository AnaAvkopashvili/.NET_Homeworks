using PizzaRestaurant.Application.RankHistory;

namespace PizzaRestaurant.Application.Repositories
{
    public interface IRankHistoryRepository
    {
        Task<List<RankHistoryResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<double> Get(CancellationToken cancellationToken, int Id);
        Task<bool> Create(CancellationToken cancellationToken, RankHistoryResponseModel rankHistory);
        Task<bool> Exists(CancellationToken cancellationToken, int id);

    }
}
