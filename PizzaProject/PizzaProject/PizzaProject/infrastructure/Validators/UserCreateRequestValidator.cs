using FluentValidation;
using PizzaRestaurant.API.infrastructure.Models.Requests;

namespace PizzaRestaurant.API.infrastructure.Validators
{
    public class UserCreateRequestValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .Length(2, 20);

            RuleFor(x => x.LastName)
               .Length(2, 30);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber can not be empty.")
                .Matches("^[0-9]+$");
        }
    }
}
