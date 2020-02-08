using CleanArch.Domain.Entities.CategoryAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class CategoryTranslationConfig : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
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
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Language)
                .WithMany(x => x.CategoryTranslations)
                .HasForeignKey(x => x.LanguageId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}

