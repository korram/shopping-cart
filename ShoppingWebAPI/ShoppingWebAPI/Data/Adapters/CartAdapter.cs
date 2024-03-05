using ShoppingWebAPI.Data.Models;
using ShoppingWebAPI.Data.Sql;
using System.Data.SqlClient;
using Dapper;
namespace ShoppingWebAPI.Data.Adapters
{
    public class CartAdapter
    {
        public static List<Cart> List(SqlConnection conn)
        {
            var datas = conn.Query<Cart>(CartSql.List).ToList();
            return datas;
        }
        public static Cart Get(SqlConnection conn, long productId)
        {
            var data = conn.QueryFirstOrDefault<Cart>(CartSql.Get, new { ProductId = productId });
            return data;
        }
        public static long? Insert(SqlConnection conn, Cart Cart)
        {
            var id = conn.Execute(CartSql.Insert, Cart);
            return id;
        }
        public static int? Update(SqlConnection conn, Cart Cart)
        {
            var result = conn.Execute(CartSql.Update, Cart);
            return result;
        }
        public static int? Delete(SqlConnection conn, long id)
        {
            var result = conn.Execute(CartSql.Delete, new { Id = id });
            return result;
        }
        public static int? DeleteAll(SqlConnection conn)
        {
            var result = conn.Execute(CartSql.DeleteAll);
            return result;
        }
        public static int? DeleteAllTrans(SqlConnection conn, SqlTransaction tran)
        {
            var result = conn.Execute(CartSql.DeleteAll, transaction: tran);
            return result;
        }
    }
}
