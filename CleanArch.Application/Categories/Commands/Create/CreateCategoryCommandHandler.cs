using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Entities.CategoryAggregation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace CleanArch.Application.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly IRepository _repository;

        public CreateCategoryCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var translations = new List<CategoryTranslation>();

            foreach (var item in request.Translations)
            {
                Guard.Against.NullOrEmpty(item.PropertyKey, nameof(item.PropertyKey));
                Guard.Against.NullOrEmpty(item.PropertyValue, nameof(item.PropertyValue));
                Guard.Against.NegativeOrZero(item.LanguageId, nameof(item.LanguageId));

                translations.Add(new CategoryTranslation(item.PropertyKey, item.PropertyValue, item.LanguageId));
            }

            var category = new Category(request.Name, request.ParentId, translations);

            await _repository.Create(category);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
