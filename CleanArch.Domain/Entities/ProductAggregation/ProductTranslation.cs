using Ardalis.GuardClauses;

namespace CleanArch.Domain.Entities.ProductAggregation
{
    public class ProductTranslation : EntityBase
    {

        public string PropertyKey { get; }
        public string PropertyValue { get; }
        public long ProductId { get; }
        public long LanguageId { get; }
        public virtual Language Language { get; }
        public virtual Product Product { get; }

        public ProductTranslation(string propertyKey, string propertyValue, long languageId)
        {
            Guard.Against.NullOrEmpty(propertyKey, nameof(propertyKey));
            Guard.Against.NullOrEmpty(propertyValue, nameof(propertyValue));
            Guard.Against.NegativeOrZero(languageId, nameof(languageId));

            PropertyKey = propertyKey;
            PropertyValue = propertyValue;
            LanguageId = languageId;
        }

        public ProductTranslation()
        {
        }
    }
}
