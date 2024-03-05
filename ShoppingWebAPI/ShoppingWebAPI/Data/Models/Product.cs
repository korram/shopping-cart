namespace ShoppingWebAPI.Data.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
