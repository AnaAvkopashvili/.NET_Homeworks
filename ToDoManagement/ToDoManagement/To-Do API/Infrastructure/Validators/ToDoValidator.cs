using FluentValidation;
using ToDoManagement.Application.To_Do;

namespace To_Do_API.Infrastructure.Validators
{
    public class ToDoValidator : AbstractValidator<ToDoRequestPostModel>
    {
        public ToDoValidator()
        {
            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Title can not be empty")
                    .Length(0, 100);
        }
    }
}
