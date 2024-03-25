using FluentValidation;
using ToDoManagement.Application.Users.Requests;

namespace To_Do_API.Infrastructure.Validators
{
    public class UsernameValidator : AbstractValidator<UserCreateModel>
    {
        public UsernameValidator()
        {
            RuleFor(x => x.Username)
                   .NotEmpty().WithMessage("Username can not be empty")
                   .Length(0, 50);
        }
    }
}
