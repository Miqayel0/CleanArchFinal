using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CleanArch.Domain.Entities.PermissionAggregation
{
    public class Permission : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public IReadOnlyCollection<PermissionRole> PermissionRoles => _permissionRoles.AsReadOnly();

        #region Private fields

        private List<PermissionRole> _permissionRoles = new List<PermissionRole>();

        #endregion

        public void AddRole(string roleId)
        {
            if (!_permissionRoles.Any(x => x.RoleId == roleId))
            {
                _permissionRoles.Add(new PermissionRole(roleId));
            }
        }
    }
}
