using Ardalis.GuardClauses;
using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public class Language : EntityBase, IAggregateRoot
    {
        public string Name { get; }
        public IReadOnlyCollection<ProductTranslation> ProductTranslations => _productTranslations.AsReadOnly();
        public IReadOnlyCollection<CategoryTranslation> CategoryTranslations => _categoryTranslations.AsReadOnly();

        public Language(string name)
        {
            Guard.Against.NullOrWhiteSpace(name,nameof(name));

            Name = name;
        }

        private Language()
        {
        }

        #region Private fields

        private readonly List<ProductTranslation> _productTranslations = new List<ProductTranslation>();
        private readonly List<CategoryTranslation> _categoryTranslations = new List<CategoryTranslation>();

        #endregion
    }
}
