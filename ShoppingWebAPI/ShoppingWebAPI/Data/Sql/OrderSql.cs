namespace ShoppingWebAPI.Data.Sql
{
    public class OrderSql
    {
        public const string List = "SELECT *  FROM dbo.Orders";
        public const string Get = "SELECT * FROM dbo.Orders WHERE Id = @Id";
        public const string Insert = "INSERT INTO dbo.Orders (OrderDate,Status,TotalPrice)  VALUES (@OrderDate,@Status,@TotalPrice);select @@IDENTITY;";
    }
}
