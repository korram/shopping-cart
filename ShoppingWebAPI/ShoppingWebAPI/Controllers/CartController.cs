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
    public class CartController : ControllerBase
    {
        string _connectionString;
        public CartController()
        {
            _connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["ShoppingDb"];

        }
        // GET: api/<CartController>
        [HttpGet]
        public List<Cart> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var Carts = CartAdapter.List(conn);
                return Carts;
            }
        }

        // GET: api/<CartController>
        [HttpGet("{id}")]
        public Cart Get(long id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var Cart = CartAdapter.Get(conn, id);
                return Cart;
            }
        }
        // POST api/<CartController>
        [HttpPost]
        public void Post(Cart cart)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cartResult = CartAdapter.Get(conn, cart.ProductId);
                if (cartResult == null)
                {
                    var result = CartAdapter.Insert(conn, cart);
                }
                else
                {
                    var product = ProductAdapter.Get(conn, cart.ProductId);
                    if (product.StockAmount == cartResult.Amount)
                    {
                        //ignore
                    }
                    else if (product.StockAmount > cartResult.Amount)
                    {
                        cartResult.Amount++;
                        var result = CartAdapter.Update(conn, cartResult);
                    }
                    else if (product.StockAmount < cartResult.Amount)
                    {
                        cartResult.Amount = product.StockAmount;
                        var result = CartAdapter.Update(conn, cartResult);
                    }
                }
            }
        }
        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(long id, Cart cart)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                cart.Id = id;
                var result = CartAdapter.Update(conn, cart);
            }
        }
        // PUT api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = CartAdapter.Delete(conn, id);
            }
        }
        // PUT api/<CartController>/5
        [HttpDelete("DeleteAll")]
        public void Delete()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var result = CartAdapter.DeleteAll(conn);
            }
        }
    }
}
