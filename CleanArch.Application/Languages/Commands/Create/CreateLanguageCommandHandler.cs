using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Languages.Commands.Create
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, bool>
    {
        private readonly IRepository _repository;

        public CreateLanguageCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(new Language(request.Name));
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
