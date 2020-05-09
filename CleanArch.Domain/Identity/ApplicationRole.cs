using Microsoft.AspNetCore.Identity;

namespace CleanArch.Domain.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsDeleted { get; set; }
    }
}
