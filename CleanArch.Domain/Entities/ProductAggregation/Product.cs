using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Events;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities.ProductAggregation
{
    public class Product : EntityBase, IAggregateRoot
    {
        public string Name { get; }
        public string Description { get; }
        public string Photo { get; }
        public decimal DiscountedPrice { get; private set; }
        public decimal UnitPrice { get; }
        public long CategoryId { get; }
        public virtual Category Category { get; }
        public IReadOnlyCollection<ProductTranslation> Translations => _translations.AsReadOnly();

        public Product(
            string name,
            string description,
            string pictureUri,
            decimal unitPrice,
            decimal discount,
            long categoryId,
            List<ProductTranslation> translations)
        {
            Name = name;
            Description = description;
            Photo = pictureUri;
            UnitPrice = unitPrice;
            DiscountedPrice = discount;
            CategoryId = categoryId;
            _translations = translations;
        }

        public Product()
        {
        }

        public void Discount(decimal price)
        {
            DiscountedPrice = price;
            AddDomainEvent(new ProductDiscountedDomainEvent(this));
        }

        #region Privete fields

        private readonly List<ProductTranslation> _translations = new List<ProductTranslation>();

        #endregion
    }
}
