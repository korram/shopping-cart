namespace ShoppingWebAPI.Data.Sql
{
    public class StockSql
    {
        public const string Get = "SELECT * FROM dbo.Stocks WHERE ProductId = @ProductId";
        public const string Update = "UPDATE dbo.Stocks SET StockAmount = @StockAmount WHERE ProductId = @ProductId AND Id = @Id";
    }
}
