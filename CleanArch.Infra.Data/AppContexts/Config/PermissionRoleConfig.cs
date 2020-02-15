using CleanArch.Domain.Entities.PermissionAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class PermissionRoleConfig : IEntityTypeConfiguration<PermissionRole>
    {
        public void Configure(EntityTypeBuilder<PermissionRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Role)
                .WithMany(x => x.PermissionRoles)
                .HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.Permission)
                .WithMany(x => x.PermissionRoles)
                .HasForeignKey(x => x.PermissionId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
