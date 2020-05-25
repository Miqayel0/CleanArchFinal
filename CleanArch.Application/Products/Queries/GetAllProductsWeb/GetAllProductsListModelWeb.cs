using CleanArch.Application.Common.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Application.Products.Queries.GetAllProductsWeb
{
    public class GetAllProductsListModelWeb : IPagedResult<GetAllProductWebDto>
    {
        public List<GetAllProductWebDto> List { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllProductWebDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Photo { get; set; }
        public string Category { get; set; }
    }
}
