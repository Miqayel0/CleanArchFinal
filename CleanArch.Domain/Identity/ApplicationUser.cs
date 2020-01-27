using Microsoft.AspNetCore.Identity;

namespace CleanArch.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
    } 
}
