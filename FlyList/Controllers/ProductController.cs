using FlyList.Models;
using FlyList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ProductRepository productRepository) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = productRepository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("Product is null.");
            }

            productRepository.Create(newProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Key }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult ModifyProduct(Guid id, [FromBody] Product updatedProduct)
        {
            if (updatedProduct == null || updatedProduct.Key != id)
            {
                return BadRequest("Product is null or ID mismatch.");
            }

            var existingProduct = productRepository.Read(id);
            if (existingProduct == null)
            {
                return NotFound("The Product record couldn't be found.");
            }

            productRepository.Update(updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = productRepository.Read(id);
            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }

            productRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = productRepository.Read(id);
            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }

            return Ok(product);
        }
    }
}
