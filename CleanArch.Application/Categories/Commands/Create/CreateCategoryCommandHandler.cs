using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Entities.CategoryAggregation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly IAsyncRepository _repository;

        public CreateCategoryCommandHandler(IAsyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                ParentId = request.ParentId
            };

            await _repository.Create(category);

            return true;
        }
    }
}
