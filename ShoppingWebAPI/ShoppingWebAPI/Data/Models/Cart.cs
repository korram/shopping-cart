namespace ShoppingWebAPI.Data.Models
{
    public class Cart
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
