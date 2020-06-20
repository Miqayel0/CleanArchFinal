using CleanArch.Domain.Entities.OrderAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(b => b.Order).WithMany(b => b.OrderItems).HasForeignKey(b => b.OrderId);
            builder.HasOne(b => b.Product).WithMany().HasForeignKey(b => b.ProductId);
            builder.Property(oi => oi.UnitPrice)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
