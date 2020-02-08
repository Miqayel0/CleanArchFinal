using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Permission.Roles));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
