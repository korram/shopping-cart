using ShoppingWebAPI.Data.Models;
using ShoppingWebAPI.Data.Sql;
using System.Data.SqlClient;
using Dapper;
namespace ShoppingWebAPI.Data.Adapters
{
    public class OrderAdapter
    {
        public static List<Order> List(SqlConnection conn)
        {
            var datas = conn.Query<Order>(OrderSql.List).ToList();
            return datas;
        }
        public static Order Get(SqlConnection conn, long id)
        {
            var data = conn.QueryFirstOrDefault<Order>(OrderSql.Get, new { Id = id });
            return data;
        }
        public static long? Insert(SqlConnection conn, SqlTransaction tran, Order order)
        {
            var id = conn.Execute(OrderSql.Insert, order, transaction: tran);
            return id;
        }
    }
}
