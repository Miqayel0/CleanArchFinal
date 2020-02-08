using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities.CategoryAggregation
{
    public class Category : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public Category Parent { get; set; }
        public IReadOnlyCollection<Category> Children => __children.AsReadOnly();
        public IReadOnlyCollection<Product> Products => _products .AsReadOnly();
        public IReadOnlyCollection<CategoryTranslation> Translations => __translations.AsReadOnly();
       
        #region Privete fields

        private readonly List<Category> __children = new List<Category>();
        private readonly List<Product> _products = new List<Product>();
        private readonly List<CategoryTranslation> __translations = new List<CategoryTranslation>();

        #endregion
    }
}
