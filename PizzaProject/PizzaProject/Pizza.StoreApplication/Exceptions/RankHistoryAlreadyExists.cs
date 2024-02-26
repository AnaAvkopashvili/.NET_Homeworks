namespace PizzaRestaurant.Application.Exceptions
{
    public class RankHistoryAlreadyExists : Exception
    {
        public string Code = "Rank history Already Exists";

        public RankHistoryAlreadyExists(string message) : base(message) { }
    }
}
