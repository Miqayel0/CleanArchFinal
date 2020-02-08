namespace CleanArch.Domain.Entities.CategoryAggregation
{
    public class CategoryTranslation : EntityBase
    {
        public string PropertyKey { get; set; }
        public string PropertyValue { get; set; }
        public long CategoryId { get; set; }
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual Category Category { get; set; }
    }
}
