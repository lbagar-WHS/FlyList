using FlyList.Models;
using FlyList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlyItemListController(ListItemRepository listItemRepository, FlyItemListRepository flyItemListRepository) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetAllFlyListItemsById(Guid id)
        {
            var listItems = flyItemListRepository.Read(id);
            return Ok(listItems);
        }

        [HttpPost]
        public IActionResult AddFlyListItem([FromBody] FlyItemList flyItemList)
        {
            var listItem = new ListItem();

            if (listItem == null)
            {
                return BadRequest("ListItem is null.");
            }

            flyItemList.FlyItems.Add(listItem);

            flyItemListRepository.Update(flyItemList);
            return CreatedAtAction(nameof(GetListItemById), new { id = flyItemList.Id }, flyItemList);
        }

        [HttpPut("{id}")]
        public IActionResult ModifyFlyListItem(Guid id, [FromBody] ListItem updatedListItem)
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
        public IActionResult DeleteFlyListItem(Guid id)
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

        [HttpGet("listitem/{id}")]
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
