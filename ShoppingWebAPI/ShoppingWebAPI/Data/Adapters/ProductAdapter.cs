using ShoppingWebAPI.Data.Models;
using ShoppingWebAPI.Data.Sql;
using System.Data.SqlClient;
using Dapper;
namespace ShoppingWebAPI.Data.Adapters
{
    public class ProductAdapter
    {
        public static List<Product> List(SqlConnection conn)
        {
            var datas = conn.Query<Product>(ProductSql.List).ToList();
            return datas;
        }
        public static Product? Get(SqlConnection conn, long id)
        {
            var data = conn.QueryFirstOrDefault<Product>(ProductSql.Get, new { Id = id });
            return data;
        }
    }
}
