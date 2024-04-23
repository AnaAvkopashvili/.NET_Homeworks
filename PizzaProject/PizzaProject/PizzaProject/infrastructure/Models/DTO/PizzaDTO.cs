namespace PizzaRestaurant.API.infrastructure.Models.DTO
{
    public class PizzaDTO
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public int CaloryCount { get; set; }
        public bool IsDeleted { get; set; }

    }
}
