using FluentValidation;

namespace MindTheMango.Mind.Domain.Business.UserLogic.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Surname)
                .NotEmpty();
        }
    }
}