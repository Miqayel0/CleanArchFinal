using Ardalis.GuardClauses;
using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IRepository _repository;
        public CreateProductCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name,
                                      request.Description,
                                      request.PictureUri,
                                      request.UnitPrice,
                                      request.DiscountedPrice,
                                      request.CategoryId);

            foreach (var item in request.Translations)
            {
                product.AddTranslation(item.PropertyKey, item.PropertyValue, item.LanguageId);
            }

            await _repository.Create(product);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
