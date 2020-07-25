using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Queries.GetAllProductsWeb
{
    public class GetAllProductsWebQueryHandler : IRequestHandler<GetAllProductsWebQuery, GetAllProductsListModelWeb>
    {
        private readonly IRepository _repository;

        public GetAllProductsWebQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductsListModelWeb> Handle(GetAllProductsWebQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll<Product>();
            var count = query.Count();
            var list = await query.Select(x => new GetAllProductWebDto
            {
                Category = x.Category.Name,
                Name = x.Name,
                Description = x.Description,
                Discount = x.DiscountedPrice,
                Photo = x.Photo,
                Price = x.UnitPrice
            }).Skip(request.Page - 1).Take(request.Count).ToListAsync(cancellationToken);

            return new GetAllProductsListModelWeb { Count = count, CurrentPage = request.Page, PageSize = request.Count, List = list };
        }
    }
}
