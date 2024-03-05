namespace ShoppingWebAPI.Data.Sql
{
    public class CartSql
    {
        public const string List = "SELECT Carts.* ,Products.ProductCode,Products.ProductName,Products.UnitPrice,CASE WHEN Stocks.StockAmount IS NULL THEN 0 ELSE Stocks.StockAmount END AS StockAmount FROM ShoppingDB.dbo.Carts INNER JOIN dbo.Products ON Products.Id = Carts.ProductID INNER JOIN dbo.Stocks ON Products.Id = Stocks.ProductID";
        public const string Get = "SELECT Carts.* ,Products.ProductCode,Products.ProductName,Products.UnitPrice,CASE WHEN Stocks.StockAmount IS NULL THEN 0 ELSE Stocks.StockAmount END AS StockAmount FROM ShoppingDB.dbo.Carts INNER JOIN dbo.Products ON Products.Id = Carts.ProductID INNER JOIN dbo.Stocks ON Products.Id = Stocks.ProductID WHERE Carts.ProductId = @ProductId";
        public const string Insert = "INSERT INTO dbo.Carts (ProductId,Amount) VALUES (@ProductId,@Amount);select @@IDENTITY;";
        public const string Update = "UPDATE dbo.Carts SET Amount = @Amount WHERE ProductId = @ProductId AND Id = @Id";
        public const string Delete = "Delete dbo.Carts WHERE Id = @Id";
        public const string DeleteAll = "Delete dbo.Carts";
    }
}
