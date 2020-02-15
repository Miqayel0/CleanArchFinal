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
        private readonly IAsyncRepository _repository;
        public CreateProductCommandHandler(IAsyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var translations = new List<ProductTranslation>();

            foreach (var item in request.Translations)
            {
                Guard.Against.NullOrEmpty(item.PropertyKey, nameof(item.PropertyKey));
                Guard.Against.NullOrEmpty(item.PropertyValue, nameof(item.PropertyValue));
                Guard.Against.NegativeOrZero(item.LanguageId, nameof(item.LanguageId));

                translations.Add(new ProductTranslation(item.PropertyKey, item.PropertyValue, item.LanguageId));
            }

            var product = new Product(
                request.Name,
                request.Description,
                request.PictureUri,
                request.UnitPrice,
                request.CategoryId,
                translations);

            await _repository.Create(product);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
