using CleanArch.Application.Common.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Queries.GetAllProductsWeb
{
    public class GetAllProductsWebQuery : IRequest<GetAllProductsListModelWeb>, IPaging
    {
        public string Search { get; set; }
        public int Count { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}
