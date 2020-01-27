using CleanArch.Domain.Entities;
using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Permissions.Commands.AddRole
{
    public class AddRoleToPermissionCommandHandler : IRequestHandler<AddRoleToPermissionCommand, bool>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IAsyncRepository _repository;
        public AddRoleToPermissionCommandHandler(RoleManager<ApplicationRole> roleManager, IAsyncRepository repository)
        {
            _roleManager = roleManager;
            _repository = repository;
        }
        public async Task<bool> Handle(AddRoleToPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _repository.GetByIdAsync<Permission>(request.PermissionId);
            if (permission == null)
                throw new SmartException("Perrmission not found");

            var roles = await _roleManager.Roles
                .Where(x => request.Roles.Contains(x.Name))
                .ToListAsync(cancellationToken);

            if (roles.Count != request.Roles.Count)
                throw new SmartException("Role not found");

            foreach (var item in roles)
            {
                item.PermissionId = request.PermissionId;
                await _roleManager.UpdateAsync(item);
            }

            return true;
        }
    }
}
