using CleanArch.Domain.Entities.ProductAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Product.Translations));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.UnitPrice)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");
            builder.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}