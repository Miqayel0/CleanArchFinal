using CleanArch.Domain.Entities.ProductAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class ProductTranslationConfig : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.PropertyValue);
            builder.HasIndex(x => x.PropertyKey);
            builder.Property(x => x.PropertyValue)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.PropertyKey)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Language)
                .WithMany(x => x.ProductTranslations)
                .HasForeignKey(x => x.LanguageId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
