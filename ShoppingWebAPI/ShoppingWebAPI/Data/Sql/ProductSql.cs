namespace ShoppingWebAPI.Data.Sql
{
    public class ProductSql
    {
        public const string List = "SELECT [Products].* ,CASE WHEN Stocks.StockAmount IS NULL THEN 0 ELSE Stocks.StockAmount END AS StockAmount FROM [ShoppingDB].[dbo].[Products] LEFt JOIN dbo.Stocks ON Products.Id = Stocks.ProductId";
        public const string Get = "SELECT [Products].* ,CASE WhEN Stocks.StockAmount IS NULL THEN 0 ELSE Stocks.StockAmount END AS StockAmount FROM [ShoppingDB].[dbo].[Products] LEFt JOIN dbo.Stocks ON Products.Id = Stocks.ProductId WHERE Products.Id = @Id";
    }
}
