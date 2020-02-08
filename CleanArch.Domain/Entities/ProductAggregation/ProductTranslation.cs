namespace CleanArch.Domain.Entities.ProductAggregation
{
    public class ProductTranslation : EntityBase
    {
        public string PropertyKey { get; set; }
        public string PropertyValue { get; set; }
        public long ProductId { get; set; }
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual Product Product { get; set; }
    }
}
