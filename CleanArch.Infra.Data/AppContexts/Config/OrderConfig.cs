using CleanArch.Domain.Entities.OrderAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(b => b.Buyer).WithMany(b => b.Orders).HasForeignKey(b => b.BuyerId);
            builder.OwnsOne(o => o.ShipToAddress, a =>
            {
                a.WithOwner();
                a.Property(a => a.ZipCode)
                    .HasMaxLength(18)
                    .IsRequired();
                a.Property(a => a.Street)
                    .HasMaxLength(180)
                    .IsRequired();
                a.Property(a => a.State)
                    .HasMaxLength(60);
                a.Property(a => a.Country)
                    .HasMaxLength(90)
                    .IsRequired();
                a.Property(a => a.City)
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.Property(b => b.DeliveryFee)
                .HasColumnType("decimal(18,2)");
            builder.Property(b => b.TotalPrice)
                .HasColumnType("decimal(18,2)");

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}