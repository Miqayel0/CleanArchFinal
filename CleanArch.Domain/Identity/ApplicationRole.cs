using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArch.Domain.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public long? PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
