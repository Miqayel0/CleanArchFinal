using CleanArch.Domain.Entities.ProductAggregation;

namespace CleanArch.Domain.Events
{
    public class ProductDiscountedEvent : BaseDomainEvent
    {
        public Product DiscountedProduct { get; private set; }

        public ProductDiscountedEvent(Product discountedProduct)
        {
            DiscountedProduct = discountedProduct;
        }
    }
}
