using Ardalis.GuardClauses;

namespace CleanArch.Domain.Entities.CategoryAggregation
{
    public class CategoryTranslation : EntityBase
    {

        public string PropertyKey { get; private set; }
        public string PropertyValue { get; private set; }
        public long CategoryId { get; private set; }
        public long LanguageId { get; private set; }
        public virtual Language Language { get; private set; }
        public virtual Category Category { get; private set; }

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
