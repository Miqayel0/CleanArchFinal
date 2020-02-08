using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities.ProductAggregation
{
    public class Product : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }
        public decimal UnitPrice { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public IReadOnlyCollection<ProductTranslation> Translations => _translations.AsReadOnly();

        #region Privete fields

        private readonly List<ProductTranslation> _translations = new List<ProductTranslation>();

        #endregion
    }
}
