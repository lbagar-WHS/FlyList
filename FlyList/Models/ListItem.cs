namespace FlyList.Models
{
    public class ListItem : SqlEntity
    {
        public bool IsBought { get; set; }
        public int Amount { get; set; }

        public required Product Product { get; set; }
    }
}
