namespace CleanArch.Domain.Entities.OrderAggregation
{
    public enum OrderStatus
    {
        Pending = 1,
        Processing,
        Delivering,
        Delivered,
        Canceled,
        Returned
    }
}
