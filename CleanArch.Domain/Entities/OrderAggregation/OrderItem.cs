using Ardalis.GuardClauses;
using CleanArch.Domain.Entities.ProductAggregation;

namespace CleanArch.Domain.Entities.OrderAggregation
{
    public class OrderItem : EntityBase
    {
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }
        public long OrderId { get; private set; }
        public long ProductId { get; private set; }
        public Order Order { get; private set; }
        public Product Product { get; set; }

        private OrderItem()
        {           
        }

        public OrderItem(decimal unitPrice, int units, long productId)
        {

            Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice));
            Guard.Against.NegativeOrZero(units, nameof(units));
            Guard.Against.NegativeOrZero(productId, nameof(productId));

            UnitPrice = unitPrice;
            Units = units;
            ProductId = productId;
        }
    }
}
