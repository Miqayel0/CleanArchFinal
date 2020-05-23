using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Events;

namespace CleanArch.Application.Products.Commands.Events
{
    public class ProductDiscountedEvent : BaseDomainEvent
    {
        public Product DiscountedProduct { get; set; }

        public ProductDiscountedEvent(Product discountedProduct)
        {
            DiscountedProduct = discountedProduct;
        }
    }
}
