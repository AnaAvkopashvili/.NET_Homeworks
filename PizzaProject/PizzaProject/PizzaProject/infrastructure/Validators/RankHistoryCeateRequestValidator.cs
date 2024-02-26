using FluentValidation;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.Application.Pizza;
using PizzaRestaurant.Application.User;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.API.infrastructure.Validators
{
    public class RankHistoryCeateRequestValidator : AbstractValidator<RankHistoryCreateModel>
    {
        public RankHistoryCeateRequestValidator() 
        {
            RuleFor(x => x.UserId)
          .Must(UserRepository.ExistsInDataBase)
          .WithMessage("User does not exist or is deleted.");

           RuleFor(x => x.PizzaId)
          .Must(PizzaRepository.ExistsInDataBase)
          .WithMessage("Pizza does not exist or is deleted.");
        }

    }
}
