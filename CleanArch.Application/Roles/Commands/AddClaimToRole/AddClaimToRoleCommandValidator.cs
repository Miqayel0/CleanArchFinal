using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Roles.Commands.AddClaimToRole
{
    public class AddClaimToRoleCommandValidator : AbstractValidator<AddClaimToRoleCommand>
    {
        public AddClaimToRoleCommandValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty();
            RuleFor(x => x.Claims).NotEmpty();
        }
    }
}
