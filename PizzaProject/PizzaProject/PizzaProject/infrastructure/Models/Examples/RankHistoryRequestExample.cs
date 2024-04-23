using PizzaRestaurant.API.infrastructure.Models.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.infrastructure.Models.Examples
{
    public class RankHistoryRequestExample : IExamplesProvider<RankHistoryCreateModel>
    {
        public RankHistoryCreateModel GetExamples()
        {
            return new RankHistoryCreateModel
            {
                UserId = 1,
                PizzaId = 2,
                Rank = 10
            };
        }
    }
}