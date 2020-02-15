using CleanArch.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.AppContexts.Config
{
    public class RoleConfig : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ApplicationRole.PermissionRoles));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
