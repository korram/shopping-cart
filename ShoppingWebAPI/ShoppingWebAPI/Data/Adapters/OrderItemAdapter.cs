using ShoppingWebAPI.Data.Models;
using ShoppingWebAPI.Data.Sql;
using System.Data.SqlClient;
using Dapper;
using System.Transactions;

namespace ShoppingWebAPI.Data.Adapters
{
    public class OrderItemAdapter
    {
        public static List<OrderItem> List(SqlConnection conn, long orderId)
        {
            var datas = conn.Query<OrderItem>(OrderItemSql.List, new { OrderId = orderId }).ToList();
            return datas;
        }
        public static OrderItem Get(SqlConnection conn, long id)
        {
            var data = conn.QueryFirstOrDefault<OrderItem>(OrderItemSql.Get, new { Id = id });
            return data;
        }
        public static long? Insert(SqlConnection conn, SqlTransaction tran, OrderItem OrderItem)
        {
            var id = conn.Execute(OrderItemSql.Insert, OrderItem, transaction: tran);
            return id;
        }
    }
}
