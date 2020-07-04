using Ardalis.GuardClauses;
using CleanArch.Domain.Identity;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities.OrderAggregation
{
    public class Order : EntityBase, IAggregateRoot
    {
        public decimal TotalPrice { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public DateTime? FinishDt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public OrderStatus Status { get; private set; }
        public string BuyerId { get; private set; }
        public Address ShipToAddress { get; private set; }
        public ApplicationUser Buyer { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        private decimal CalculateTotal()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.UnitPrice * item.Units;
            }
            total += DeliveryFee;
            return total;
        }

        private Order()
        {
        }

        public Order(
            string buyerId, Address shipToAddress, DateTime? finishDt,
            OrderStatus status, decimal deliveryFee)
        {
            var totalPrice = CalculateTotal();
            Guard.Against.NullOrWhiteSpace(buyerId, nameof(buyerId));
            Guard.Against.Null(shipToAddress, nameof(shipToAddress));
            Guard.Against.Default(shipToAddress, nameof(shipToAddress));
            Guard.Against.NegativeOrZero(deliveryFee, nameof(deliveryFee));
            Guard.Against.NegativeOrZero(totalPrice, nameof(totalPrice));

            BuyerId = buyerId;
            ShipToAddress = shipToAddress;
            FinishDt = finishDt;
            Status = status;
            DeliveryFee = deliveryFee;
            TotalPrice = totalPrice;
        }

        public void AddOrderItem(decimal unitPrice, int units, long productId)
        {
            _orderItems.Add(new OrderItem(unitPrice, units, productId));
        }

        #region Private fields

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        #endregion Private fealds
    }
}