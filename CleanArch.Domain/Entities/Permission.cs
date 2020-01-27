using CleanArch.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public class Permission : EntityBase
    {
        public Permission()
        {
            Roles = new HashSet<ApplicationRole>();
        }

        public string Name { get; set; }
        public ICollection<ApplicationRole> Roles { get; set; }
    }
}
