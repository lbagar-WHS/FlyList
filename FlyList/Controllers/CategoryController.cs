using FlyList.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlyList.Controllers
{
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateCategory(string name)
        {
            return Ok("");
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok("");
        }

        [HttpPut]
        public IActionResult ModifyCategory([FromBody] Category category)
        {
            return Ok("");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            return Ok("");
        }
    }
}
