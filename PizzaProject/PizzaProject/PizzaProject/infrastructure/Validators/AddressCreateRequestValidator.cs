using FluentValidation;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.Application.User;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.API.infrastructure.Validators
{
    public class AddressCreateRequestValidator : AbstractValidator<AddressCreateModel>
    {
       public AddressCreateRequestValidator()
       {
            RuleFor(x => x.UserId)
            .Must(UserRepository.ExistsInDataBase).WithMessage("User does not exist or is deleted.")
            .Must(value => value >= 1)
            .WithMessage("Users Id can not be less than 1.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City can not be emoty")
                .Length(0, 15);

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country can not be emoty")
                .Length(0, 15);

            RuleFor(x => x.Region)
                .NotEmpty().WithMessage("Region can not be emoty")
                .Length(0, 15);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description can not be emoty")
                .Length(0, 100);
        } 
    }
}
