using FlyList.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(new List<Product>());
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

        [HttpDel]
        public IActionResult DeleteProduct(Guid productId)
        {
            return Ok("");
        }

    }
}
