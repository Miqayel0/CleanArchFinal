using CleanArch.Domain.Entities.ProductAggregation;
using MediatR;

namespace CleanArch.Application.Products.Commands.Events
{
    public class ProductDiscountedEvent : INotification
    {
        public Product DiscountedProduct { get; set; }

        public ProductDiscountedEvent(Product discountedProduct)
        {
            DiscountedProduct = discountedProduct;
        }

    }
}
