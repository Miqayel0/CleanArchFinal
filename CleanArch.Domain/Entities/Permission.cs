using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public class Permission : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public IReadOnlyCollection<ApplicationRole> Roles => _roles.AsReadOnly();

        #region Private fields

        public List<ApplicationRole> _roles = new List<ApplicationRole>();

        #endregion
    }
}
