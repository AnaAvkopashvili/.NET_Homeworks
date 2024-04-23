namespace PizzaRestaurant.Application.Exceptions
{
    public class RankHistoryNotFound : Exception
    {
        public string Code = "rank history not found";
        public RankHistoryNotFound(string message) : base(message) { }
    }
}
