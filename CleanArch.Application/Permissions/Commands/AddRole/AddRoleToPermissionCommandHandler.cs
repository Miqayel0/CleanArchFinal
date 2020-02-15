using CleanArch.Domain.Entities.PermissionAggregation;
using CleanArch.Domain.Exeptions;
using CleanArch.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Permissions.Commands.AddRole
{
    public class AddRoleToPermissionCommandHandler : IRequestHandler<AddRoleToPermissionCommand, bool>
    {
        private readonly IAsyncRepository _repository;
        public AddRoleToPermissionCommandHandler(IAsyncRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(AddRoleToPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await _repository.GetByIdAsync<Permission>(request.PermissionId);
            if (permission == null)
                throw new SmartException("Perrmission not found");

            foreach (var item in request.RoleIds)
            {
                permission.AddRole(item);
            }

            await _repository.Update(permission);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
