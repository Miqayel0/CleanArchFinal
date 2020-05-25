using CleanArch.Domain.Entities.ProductAggregation;
using MediatR;

namespace CleanArch.Domain.Events
{
    public class ProductDiscountedDomainEvent : INotification
    {
        public Product DiscountedProduct { get; private set; }

        public ProductDiscountedDomainEvent(Product discountedProduct)
        {
            DiscountedProduct = discountedProduct;
        }
    }
}
