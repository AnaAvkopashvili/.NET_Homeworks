using Mapster;
using PizzaRestaurant.Application.Exceptions;
using PizzaRestaurant.Application.Pizza;
using PizzaRestaurant.Application.Repositories;

namespace PizzaRestaurant.Infrastructure.Pizzas
{
    public class PizzaRepository : IPizzaRepository
    {
        private static List<PizzaResponseModel> _pizzas = new List<PizzaResponseModel>
        {
            new PizzaResponseModel{Id = 1, Name = "Peperoni Pizza", Description = " tomato sauce, mozzarella cheese, pepperoni sausage", Price = 20.0m, CaloryCount = 500, IsDeleted = false },
            new PizzaResponseModel{Id = 2, Name = "Margherita", Description = "tomato sauce, white mozzarella, basil", Price = 18.0m, CaloryCount = 400 , IsDeleted = false},
            new PizzaResponseModel{Id = 3, Name = "4 Cheese pizza", Description = "mozzarella, Parmesan, blue cheese, stracchino", Price = 20.0m, CaloryCount = 600, IsDeleted = false  }
        };
        public async Task<PizzaResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await Task.FromResult(_pizzas.SingleOrDefault(x => x.Id == id && !x.IsDeleted));
        }

        public async Task<List<PizzaResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_pizzas);
        }
        public async Task Create(CancellationToken cancellationToken, PizzaRequestModel pizza)
        {
            if (_pizzas.Exists(x => x.Id == pizza.Id))
                throw new PizzaAlreadyExists("Pizza already Exists");

            var result = pizza.Adapt<PizzaResponseModel>();
            result.Id = _pizzas.Max(x => x.Id) + 1;
            _pizzas.Add(result);
        }

        public async Task Update(CancellationToken cancellationToken, PizzaRequestModel pizza)
        {
            var existingPizza = await Get(cancellationToken, pizza.Id);
            if (existingPizza == null)
            {
                throw new PizzaNotFound("Pizza with this id was not found");
            }

            existingPizza.Name = pizza.Name;
            existingPizza.Price = pizza.Price;
            existingPizza.Description = pizza.Description;
            existingPizza.CaloryCount = pizza.CaloryCount;

            pizza.Adapt<PizzaResponseModel>();
        }
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            var pizza = await Get(cancellationToken, id);
            if (pizza == null)
            {
                throw new PizzaNotFound("Pizza with this id was not found");
            }
            pizza.IsDeleted = true;
        }

        public Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var result = _pizzas.Find(x => x.Id == id);
            return Task.FromResult(!(result == null));
        }
        public static bool ExistsInDataBase(int pizzaId)
        {
            return _pizzas.Any(x => x.Id == pizzaId && !x.IsDeleted);
        }

        public static bool ValidatePizzas(List<int> pizzaIds)
        {
           foreach(var item in pizzaIds)
           {
                var result = _pizzas.Any(x => x.Id == item);
                if (!result)
                {
                    return false;
                }
           }
            return true;
        }
    }
}
