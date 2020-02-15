using FluentValidation;

namespace CleanArch.Application.Languages.Commands.Create
{
    public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
