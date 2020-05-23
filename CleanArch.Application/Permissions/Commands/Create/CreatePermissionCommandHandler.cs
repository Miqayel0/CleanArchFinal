using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.PermissionAggregation;
using CleanArch.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Permissions.Commands.Create
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, bool>
    {
        private readonly IAsyncRepository _repository;

        public CreatePermissionCommandHandler(IAsyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(new Permission(request.Name));
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
