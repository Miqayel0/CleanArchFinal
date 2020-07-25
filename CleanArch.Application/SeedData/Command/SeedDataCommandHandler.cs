using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.SeedData.Command
{
    public class SeedDataCommandHandler : IRequestHandler<SeedDataCommand, bool>
    {
        private readonly IRepository _repository;

        public SeedDataCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            await AddCategory();
            return true;
        }

        public Task AddCategory()
        {
            //var parentCategory = new Category("Food", null, new List<CategoryTranslation>
            //{
            //    new CategoryTranslation("Name","Food",1),
            //    new CategoryTranslation("Name","Մթերք",2),
            //    new CategoryTranslation("Name","Продукт",3)
            //});

            //var resultParentCategory = await _repository.Create(parentCategory);

            //var categoryLevelTwo = new Category("Sweet", resultParentCategory.Id, new List<CategoryTranslation>
            //{
            //    new CategoryTranslation("Name","Sweet",1),
            //    new CategoryTranslation("Name","Քաղցրավենիք",2),
            //    new CategoryTranslation("Name","сладости",3)
            //});

            //var resultCategoryLevelTeo = await _repository.Create(categoryLevelTwo);

            //var categoryLevelThree = new Category("Sweet", resultCategoryLevelTeo.Id, new List<CategoryTranslation>
            //{
            //    new CategoryTranslation("Name","Sweet",1),
            //    new CategoryTranslation("Name","Քաղցրավենիք",2),
            //    new CategoryTranslation("Name","сладости",3)
            //});

            //await _repository.Create(categoryLevelThree);


            ////await _repository.CreateRange(new List<Category> { parentCategory, categoryLevelTwo, categoryLevelThree });
            //await _repository.CompleteAsync();

            throw new NotImplementedException();
        }
    }
}
