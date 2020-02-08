using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            var prodNavigation = builder.Metadata.FindNavigation(nameof(Language.ProductTranslations));
            prodNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            var catNavigation = builder.Metadata.FindNavigation(nameof(Language.CategoryTranslations));
            catNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(10);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
