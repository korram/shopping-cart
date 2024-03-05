namespace ShoppingWebAPI.Data.Models
{
    public class Stock
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int StockAmount { get; set; }
    }
}
