namespace FlyList.Models
{
    public class FlyItemList : SqlEntity
    {
        public string? Name { get; set; }
        public List<Guid>? FlyItemIds { get; set; }

        public List<ListItem> FlyItems { get; set; } = [];
    }
}
