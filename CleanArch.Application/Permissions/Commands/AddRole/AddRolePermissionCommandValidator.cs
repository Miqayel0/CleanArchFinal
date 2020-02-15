using FluentValidation;

namespace CleanArch.Application.Permissions.Commands.AddRole
{
    public class AddRolePermissionCommandValidator : AbstractValidator<AddRoleToPermissionCommand>
    {
        public AddRolePermissionCommandValidator()
        {
            RuleFor(x => x.PermissionId).NotEmpty();
            RuleFor(x => x.RoleIds).NotEmpty();
        }
    }
}
