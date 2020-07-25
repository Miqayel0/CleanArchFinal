using Ardalis.GuardClauses;
using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Events;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities.ProductAggregation
{
    public class Product : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Photo { get; private set; }
        public decimal DiscountedPrice { get; private set; }
        public decimal UnitPrice { get; private set; }
        public long CategoryId { get; private set; }
        public virtual Category Category { get; private set; }
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