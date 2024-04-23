using FluentValidation;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.Application.User;
using PizzaRestaurant.Application.Pizza;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.Users;
using PizzaRestaurant.Infrastructure.Orders;

namespace PizzaRestaurant.API.infrastructure.Validators
{
    public class OrderCreateRequestValidator : AbstractValidator<OrderCreateModel>
    {
        public OrderCreateRequestValidator()
        {
            RuleFor(x => x.UserId)
            .Must(UserRepository.ExistsInDataBase)
            .WithMessage("User does not exist or is deleted.");

            RuleFor(x => x.Pizzas)
           .NotEmpty().WithMessage("List of pizzas cannot be empty.")
           .ForEach(pizzaRule =>
           {
               pizzaRule.Must(pizza => PizzaRepository.ExistsInDataBase(pizza.Id))
                   .WithMessage("Pizza does not exist or is deleted.");
           });
        }
    }
}
