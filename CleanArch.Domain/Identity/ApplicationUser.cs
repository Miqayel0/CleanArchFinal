using CleanArch.Domain.Entities.OrderAggregation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CleanArch.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PictureUri { get; set; }
        public bool IsDeleted { get; set; }

        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        #region Private fields

        private readonly List<Order> _orders = new List<Order>();

        #endregion Private fields
    }
}