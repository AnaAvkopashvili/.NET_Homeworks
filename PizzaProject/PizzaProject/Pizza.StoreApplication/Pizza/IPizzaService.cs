namespace PizzaRestaurant.Application.Pizza
{
    public interface IPizzaService
    {
        Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<PizzaResponseModel> Get(CancellationToken cancellationToken, int id);
        Task Create(CancellationToken cancellationToken, PizzaRequestModel pizza);
        Task Update(CancellationToken cancellationToken, PizzaRequestModel pizza);
        Task Delete(CancellationToken cancellationToken, int id);
    }
}
