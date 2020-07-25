using Ardalis.GuardClauses;
using CleanArch.Domain.Entities.ProductAggregation;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities.CategoryAggregation
{
    public class Category : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public long? ParentId { get; private set; }
        public Category Parent { get; private set; }
        public IReadOnlyCollection<Category> Children => _children.AsReadOnly();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
        public IReadOnlyCollection<CategoryTranslation> Translations => _translations.AsReadOnly();

        public Category(string name, long? parentId = null)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            Name = name;
            ParentId = parentId;
        }

        private Category()
        {
        }

        public void AddTranslation(string propertyKey, string propertyValue, long languageId)
        {
            _translations.Add(new CategoryTranslation(propertyKey, propertyValue, languageId));
        }


        #region Privete fields

        private readonly List<Category> _children = new List<Category>();
        private readonly List<Product> _products = new List<Product>();
        private readonly List<CategoryTranslation> _translations = new List<CategoryTranslation>();

        #endregion
    }
}
