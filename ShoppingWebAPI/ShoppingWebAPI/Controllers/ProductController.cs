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
    public class ProductController : ControllerBase
    {
        string _connectionString ;
        public ProductController()
        {
            _connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["ShoppingDb"];

        }
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var products = ProductAdapter.List(conn);
                return products;
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(long id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var product = ProductAdapter.Get(conn, id);
                return product;
            }
        }
    }
}
