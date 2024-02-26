using PizzaRestaurant.Application.RankHistory;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{

    public class RankHistoryResponseExample : IExamplesProvider<RankHistoryResponseModel>
    {
        public RankHistoryResponseModel GetExamples()
        {
            return new RankHistoryResponseModel
            {
                UserId = 1,
                PizzaId = 2,
                Rank = 5
            };
        }
    }
}
