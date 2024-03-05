namespace ShoppingWebAPI.Data.Sql
{
    public class OrderItemSql
    {
        public const string List = "SELECT *  FROM dbo.OrderItems WHERE OrderId = @OrderId";
        public const string Get = "SELECT * FROM dbo.OrderItems WHERE Id = @Id";
        public const string Insert = "INSERT INTO dbo.OrderItems (OrderId,ProductId,UnitPrice,Amount)  VALUES (@OrderId,@ProductId,@UnitPrice,@Amount);select @@IDENTITY;";
    }
}
