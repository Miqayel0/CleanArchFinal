using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities.ProductAggregation
{
    public class Product : EntityBase, IAggregateRoot
    {
        public string Name { get; }
        public string Description { get; }
        public string PictureUri { get; }
        public decimal UnitPrice { get; }
        public long CategoryId { get; }
        public virtual Category Category { get; }
        public IReadOnlyCollection<ProductTranslation> Translations => _translations.AsReadOnly();

        public Product(
            string name,
            string description,
            string pictureUri,
            decimal unitPrice,
            long categoryId,
            List<ProductTranslation> translations)
        {
            Name = name;
            Description = description;
            PictureUri = pictureUri;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
            _translations = translations;
        }

        public Product()
        {
        }

        #region Privete fields

        private readonly List<ProductTranslation> _translations = new List<ProductTranslation>();

        #endregion
    }
}
