using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Roles.Commands.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, bool>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _roleManager.RoleExistsAsync(request.Name))
                throw new SmartException("Role already exists");

            var result = await _roleManager.CreateAsync(new ApplicationRole { Name = request.Name });
            if (!result.Succeeded)
                throw new SmartException(string.Join(Environment.NewLine, result.Errors));

            return true;
        }
    }
}
