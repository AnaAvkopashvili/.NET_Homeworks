namespace PizzaRestaurant.API.infrastructure.Models.Requests
{
    public class PizzaCreateModel
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
