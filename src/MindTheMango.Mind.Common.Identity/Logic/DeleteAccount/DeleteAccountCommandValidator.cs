using FluentValidation;

namespace MindTheMango.Mind.Common.Identity.Logic.DeleteAccount
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}