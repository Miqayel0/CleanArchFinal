using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Entities.ProductAggregation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IAsyncRepository _repository;

        public CreateProductCommandHandler(IAsyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var Product = new Product
            {
                Name = request.Name,
                ParentId = request.ParentId
            };

            await _repository.Create(Product);

            return true;
        }
    }
}
