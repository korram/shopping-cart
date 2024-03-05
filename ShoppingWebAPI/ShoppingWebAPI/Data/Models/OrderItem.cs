namespace ShoppingWebAPI.Data.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
