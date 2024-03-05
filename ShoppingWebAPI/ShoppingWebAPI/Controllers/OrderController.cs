using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShoppingWebAPI.Data.Adapters;
using ShoppingWebAPI.Data.Models;
using System.Data.SqlClient;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        string _connectionString;
        public OrderController()
        {
            _connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["ShoppingDb"];

        }
        // GET: api/<OrderController>
        [HttpGet]
        public List<Order> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var Orders = OrderAdapter.List(conn);
                return Orders;
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order Get(long id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var order = OrderAdapter.Get(conn, id);
                order.OrderItems = OrderItemAdapter.List(conn, id);
                return order;
            }
        }

        // POST api/<OrderController>
        [HttpPost]
        public long? Post(Order order)
        {
            long? id = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    id = OrderAdapter.Insert(conn, tran, order);
                    foreach (var orderItem in order.OrderItems)
                    {
                        orderItem.OrderId = id.Value;
                        OrderItemAdapter.Insert(conn, tran, orderItem);
                    }
                    tran.Commit();
                }
            }
            return id;
        }
        // POST api/<OrderController>
        [HttpPost("createOrder")]
        public long? createOrder()
        {
            long? id = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                var carts = CartAdapter.List(conn);
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    var order = new Order();
                    order.TotalPrice = carts.Sum(t => (t.UnitPrice * t.Amount));
                    order.Status = OrderStatus.Completed;
                    var orderId = OrderAdapter.Insert(conn, tran, order);
                    foreach (var cart in carts)
                    {
                        var stock = StockAdapter.Get(conn, tran, cart.ProductId);
                        stock.StockAmount -= cart.Amount;
                        StockAdapter.Update(conn, tran, stock);

                        var orderItem = new OrderItem();
                        orderItem.OrderId = orderId.Value;
                        orderItem.ProductId = cart.ProductId;
                        orderItem.UnitPrice = cart.UnitPrice;
                        orderItem.Amount = cart.Amount;
                        OrderItemAdapter.Insert(conn, tran, orderItem);
                    }
                    CartAdapter.DeleteAllTrans(conn, tran);
                    tran.Commit();
                }
            }
            return id;
        }
    }
}
