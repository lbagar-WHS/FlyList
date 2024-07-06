using FlyList.Models;
using FlyList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListItemController(ListItemRepository listItemRepository) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllListItems()
        {
            var listItems = listItemRepository.GetAll();
            return Ok(listItems);
        }

        [HttpPost]
        public IActionResult AddListItem([FromBody] ListItem newListItem)
        {
            if (newListItem == null)
            {
                return BadRequest("ListItem is null.");
            }

            listItemRepository.Create(newListItem);
            return CreatedAtAction(nameof(GetListItemById), new { id = newListItem.Id }, newListItem);
        }

        [HttpPut("{id}")]
        public IActionResult ModifyListItem(Guid id, [FromBody] ListItem updatedListItem)
        {
            if (updatedListItem == null || updatedListItem.Id != id)
            {
                return BadRequest("ListItem is null or ID mismatch.");
            }

            var existingListItem = listItemRepository.Read(id);
            if (existingListItem == null)
            {
                return NotFound("The ListItem record couldn't be found.");
            }

            listItemRepository.Update(updatedListItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteListItem(Guid id)
        {
            var listItem = listItemRepository.Read(id);
            if (listItem == null)
            {
                return NotFound("The ListItem record couldn't be found.");
            }

            listItemRepository.Delete(id);
            return NoContent();
        }

        [HttpDelete("clear")]
        public IActionResult ClearAllListItems()
        {
            var allItems = listItemRepository.GetAll();
            foreach (var item in allItems)
            {
                listItemRepository.Delete(item.Id);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetListItemById(Guid id)
        {
            var listItem = listItemRepository.Read(id);
            if (listItem == null)
            {
                return NotFound("The ListItem record couldn't be found.");
            }

            return Ok(listItem);
        }
    }
}
