namespace PizzaRestaurant.API.infrastructure.Models.Requests
{
    public class PizzaPutModel
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string PizzaDescription { get; set; }
        public int CaloryCount { get; set; }
    }
}
