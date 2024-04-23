namespace PizzaRestaurant.Application.Pizza
{
    public class PizzaRequestModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public int CaloryCount { get; set; }
    }
}
