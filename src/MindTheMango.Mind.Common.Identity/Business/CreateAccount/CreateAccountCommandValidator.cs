using System.Linq;
using FluentValidation;

namespace MindTheMango.Mind.Common.Identity.Business.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Username)
                .NotEmpty()
                .Length(3, 20);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Must(pass => pass.Any(char.IsDigit))
                .Must(pass => pass.Any(char.IsLower));
        }
    }
}