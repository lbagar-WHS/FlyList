using FlyList.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListItemController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllListItems()
        {
            return Ok(new List<ListItem>());
        }

        [HttpPost]
        public IActionResult AddListItem([FromBody] Product newListItem)
        {
            return Ok("");
        }

        [HttpPut]
        public IActionResult ModifyListItem([FromBody] ListItem listItemId)
        {
            return Ok("");
        }

        [HttpDelete]
        public IActionResult DeleteListItem(Guid productId)
        {
            return Ok("");
        }

        [HttpDelete]
        public IActionResult ClearAllListItems()
        {
            return Ok("");
        }
    }
}
