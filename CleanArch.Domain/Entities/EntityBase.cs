using CleanArch.Domain.Events;
using System;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDt { get; set; }
        public bool IsDeleted { get; set; }

        private List<BaseDomainEvent> _domainEvents;
        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvents ??= new List<BaseDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
