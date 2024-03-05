namespace ShoppingWebAPI.Data.Models
{
    public class OrderStatus
    {
        public const string Pending = "Pending";
        public const string Completed = "Completed";
    }
    public class Order
    {
        public long Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string? Status { get; set; } = OrderStatus.Pending;
        public List<OrderItem>? OrderItems { get; set; }
    }
}
