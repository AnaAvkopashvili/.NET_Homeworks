using FluentValidation;
using PizzaRestaurant.API.infrastructure.Models.Requests;

namespace PizzaRestaurant.API.infrastructure.Validators
{
    public class PizzaCreateRequestValidator : AbstractValidator<PizzaCreateModel>
    {
        public PizzaCreateRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .Length(3, 20).WithMessage("Name must be between 3 and 20 characters.");

            RuleFor(x => x.Price)
                .Must(value => value > 0).WithMessage("Price can not be empty and it should be greater than 0.");

            When(x => !string.IsNullOrEmpty(x.Description), () =>
            {
                RuleFor(x => x.Description)
                 .Length(0, 100).WithMessage("Description should be <= 100");
            });

            RuleFor(x => x.CaloryCount)
                .Must(value => value > 0).WithMessage("CaloryCount can not be empty and it should be greater than 0.");

        }
    }
}
