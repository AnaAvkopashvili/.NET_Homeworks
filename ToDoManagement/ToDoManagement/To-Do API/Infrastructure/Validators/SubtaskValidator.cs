using To_Do.Application.Subtasks.Requests;
using FluentValidation;

namespace To_Do_API.Infrastructure.Validators
{
    public class SubtaskValidator : AbstractValidator<SubtaskRequestPostModel>
    {
        public SubtaskValidator()
        {
            RuleFor(x => x.Title)
                  .NotEmpty().WithMessage("Title can not be empty")
                  .Length(0, 100);
        }
    }
}
