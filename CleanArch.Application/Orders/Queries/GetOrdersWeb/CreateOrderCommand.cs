using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArch.Application.Orders.Queries.GetOrdersWeb
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public DateTime? FinishDt { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }

    public class BasketItem
    {
        public long ProductId { get; set; }
        public int Units { get; set; }
    }
}
