using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CleanArch.Domain.Entities.PermissionAggregation
{
    public class Permission : EntityBase, IAggregateRoot
    {
        public string Name { get; }
        public IReadOnlyCollection<PermissionRole> PermissionRoles => _permissionRoles.AsReadOnly();
        public void AddRole(string roleId)
        {
            if (!_permissionRoles.Any(x => x.RoleId == roleId))
            {
                _permissionRoles.Add(new PermissionRole(roleId));
            }
        }


        public Permission(string name)
        {
            Name = name;
        }


        public Permission()
        { }

        #region Private fields

        private List<PermissionRole> _permissionRoles = new List<PermissionRole>();

        #endregion


    }
}
