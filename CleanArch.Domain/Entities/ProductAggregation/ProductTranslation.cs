using Ardalis.GuardClauses;

namespace CleanArch.Domain.Entities.ProductAggregation
{
    public class ProductTranslation : EntityBase
    {

        public string PropertyKey { get; private set; }
        public string PropertyValue { get; private set; }
        public long ProductId { get; private set; }
        public long LanguageId { get; private set; }
        public virtual Language Language { get; private set; }
        public virtual Product Product { get; private set; }

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
