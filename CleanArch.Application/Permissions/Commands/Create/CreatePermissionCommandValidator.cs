using FluentValidation;

namespace CleanArch.Application.Permissions.Commands.Create
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
