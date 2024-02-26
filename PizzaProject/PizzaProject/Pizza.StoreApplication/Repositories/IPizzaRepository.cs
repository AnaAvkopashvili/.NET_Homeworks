using PizzaRestaurant.Application.Pizza;

namespace PizzaRestaurant.Application.Repositories
{
    public interface IPizzaRepository
    {
        Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<PizzaResponseModel> Get(CancellationToken cancellationToken, int id);
        Task Create(CancellationToken cancellationToken, PizzaRequestModel pizza);
        Task Update(CancellationToken cancellationToken, PizzaRequestModel pizza);
        Task Delete(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);

    }
}
