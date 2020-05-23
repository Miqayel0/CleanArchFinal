using MediatR;
using System;

namespace CleanArch.Domain.Events
{
    public class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
