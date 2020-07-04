using Ardalis.GuardClauses;
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
            long categoryId)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NegativeOrZero(discount, nameof(discount));
            Guard.Against.NegativeOrZero(categoryId, nameof(categoryId));

            Name = name;
            Description = description;
            Photo = pictureUri;
            UnitPrice = unitPrice;
            DiscountedPrice = discount;
            CategoryId = categoryId;
        }

        private Product()
        {
        }

        public void AddTranslation(string propertyKey, string propertyValue, long languageId)
        {
            _translations.Add(new ProductTranslation(propertyKey, propertyValue, languageId));
        }
        public void Discount(decimal price)
        {
            DiscountedPrice = price;
            AddDomainEvent(new ProductDiscountedDomainEvent(this));
        }

        #region Privete fields

        private readonly List<ProductTranslation> _translations = new List<ProductTranslation>();

        #endregion Privete fields
    }
}