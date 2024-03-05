using ShoppingWebAPI.Data.Models;
using ShoppingWebAPI.Data.Sql;
using System.Data.SqlClient;
using Dapper;
namespace ShoppingWebAPI.Data.Adapters
{
    public class StockAdapter
    {
        public static Stock? Get(SqlConnection conn, SqlTransaction tran, long productId)
        {
            var data = conn.QueryFirstOrDefault<Stock>(StockSql.Get, new { ProductId = productId }, transaction: tran);
            return data;
        }
        public static int? Update(SqlConnection conn,SqlTransaction tran, Stock Stock)
        {
            var result = conn.Execute(StockSql.Update, Stock, transaction: tran);
            return result;
        }
    }
}
