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
            var category = new Category(request.Name, request.ParentId);

            foreach (var item in request.Translations)
            {
                category.AddTranslation(item.PropertyKey, item.PropertyValue, item.LanguageId);
            }
 
            await _repository.Create(category);
            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
