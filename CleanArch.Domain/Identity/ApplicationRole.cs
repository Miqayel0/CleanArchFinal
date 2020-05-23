using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.PermissionAggregation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CleanArch.Domain.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsDeleted { get; set; }
        public IReadOnlyCollection<PermissionRole> PermissionRoles => _permissionRoles.AsReadOnly();

        #region Private fields

        private readonly List<PermissionRole> _permissionRoles = new List<PermissionRole>();

        #endregion
    }
}
