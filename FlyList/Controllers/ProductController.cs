using FlyList.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return new List<Product>();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]Product newProduct)
        {
            return Ok("");
        }

        [HttpPut]
        public IActionResult ModifyProduct([FromBody] Product product)
        {
            return Ok("");
        }

    }
}
