namespace PizzaRestaurant.Application.RankHistory
{
    public interface IRankHistoryService
    {
        Task<List<RankHistoryResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<double> Get(CancellationToken cancellationToken, int Id);
        Task<bool> Create(CancellationToken cancellationToken, RankHistoryResponseModel rankHistory);
    }
}
