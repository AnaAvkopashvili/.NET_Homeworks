using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Repositories;

namespace PizzaRestaurant.Application.Pizza
{

    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repository;

        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PizzaResponseModel> Get(CancellationToken cancellationToken, int Id)
        {
            var result = await _repository.Get(cancellationToken, Id);

            if (result == null)
                throw new PizzaNotFound(Id.ToString());
            else
                return result;
        }

        public async Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }
        public async Task Create(CancellationToken cancellationToken, PizzaRequestModel pizza)
        {
            await _repository.Create(cancellationToken, pizza);
        }

        public async Task Update(CancellationToken cancellationToken, PizzaRequestModel pizza)
        {
            if (!await _repository.Exists(cancellationToken, pizza.Id))
                throw new PizzaNotFound(pizza.Id.ToString());

            await _repository.Update(cancellationToken, pizza);
        }
        public async Task Delete(CancellationToken cancellationToken, int Id)
        {
            if (!await _repository.Exists(cancellationToken, Id))
                throw new PizzaNotFound(Id.ToString());

            await _repository.Delete(cancellationToken, Id);
        }
    }
}
