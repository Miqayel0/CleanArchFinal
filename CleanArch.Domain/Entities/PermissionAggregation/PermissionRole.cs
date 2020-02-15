using CleanArch.Domain.Identity;
namespace CleanArch.Domain.Entities.PermissionAggregation
{
    public class PermissionRole : EntityBase
    {
        public long PermissionId { get; }
        public string RoleId { get; }
        public Permission Permission { get; }
        public ApplicationRole Role { get; }

        public PermissionRole(string roleId)
        {
            RoleId = roleId;
        }
    }
}
