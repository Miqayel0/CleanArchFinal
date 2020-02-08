using CleanArch.Domain.Entities.CategoryAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Category.Products));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}

