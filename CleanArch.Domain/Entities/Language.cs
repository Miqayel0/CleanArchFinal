using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public class Language : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public IReadOnlyCollection<ProductTranslation> ProductTranslations => _productTranslations.AsReadOnly();
        public IReadOnlyCollection<CategoryTranslation> CategoryTranslations => _categoryTranslations.AsReadOnly();

        #region Private fields

        private readonly List<ProductTranslation> _productTranslations = new List<ProductTranslation>();
        private readonly List<CategoryTranslation> _categoryTranslations = new List<CategoryTranslation>();

        #endregion
    }
}
