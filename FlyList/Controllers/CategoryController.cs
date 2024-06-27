using FlyList.Models;
using FlyList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlyList.Controllers
{
    public class CategoryController(CategoryRepository categoryRepository) : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateCategory(string name)
        {
            try
            {
                var category = new Category { Name = name };
                categoryRepository.Create(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Key }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = categoryRepository.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyCategory(Guid id, [FromBody] Category category)
        {
            if (category == null || category.Key != id)
            {
                return BadRequest("Category is null or ID mismatch.");
            }

            try
            {
                var existingCategory = categoryRepository.Read(id);
                if (existingCategory == null)
                {
                    return NotFound("The Category record couldn't be found.");
                }

                categoryRepository.Update(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            try
            {
                var category = categoryRepository.Read(id);
                if (category == null)
                {
                    return NotFound("The Category record couldn't be found.");
                }

                categoryRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(Guid id)
        {
            try
            {
                var category = categoryRepository.Read(id);
                if (category == null)
                {
                    return NotFound("The Category record couldn't be found.");
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
