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
            string buyerId, Address shipToAddress, List<OrderItem> items, DateTime? finishDt,
            OrderStatus status, decimal deliveryFee)
        {
            BuyerId = buyerId;
            ShipToAddress = shipToAddress;
            _orderItems = items;
            FinishDt = finishDt;
            Status = status;
            DeliveryFee = deliveryFee;
            TotalPrice = CalculateTotal();
        }

        #region Private fields

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        #endregion Private fealds
    }
}