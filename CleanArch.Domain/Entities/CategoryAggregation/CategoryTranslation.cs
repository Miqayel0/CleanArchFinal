using Ardalis.GuardClauses;

namespace CleanArch.Domain.Entities.CategoryAggregation
{
    public class CategoryTranslation : EntityBase
    {

        public string PropertyKey { get; }
        public string PropertyValue { get; }
        public long CategoryId { get; }
        public long LanguageId { get; }
        public virtual Language Language { get; }
        public virtual Category Category { get; }

        public CategoryTranslation(string propertyKey, string propertyValue, long languageId)
        {
            Guard.Against.NullOrWhiteSpace(propertyKey, nameof(propertyKey));
            Guard.Against.NullOrWhiteSpace(propertyValue, nameof(propertyValue));
            Guard.Against.NegativeOrZero(languageId, nameof(languageId));

            PropertyKey = propertyKey;
            PropertyValue = propertyValue;
            LanguageId = languageId;
        }

        public CategoryTranslation()
        {
        }
    }
}
