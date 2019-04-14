using FluentValidation;

namespace MindTheMango.Mind.Domain.Business.Notes.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}