using ActionRpg.Models.ItemModels;

namespace ActionRpg.Models.Interfaces
{
    public interface IItem
    {
        public bool CreateItem(Item item);
        public bool CreateItems(Item[] items);
        public Item GetItem(string itemID);
        public Item[] GetItems(string[] itemID);
        public bool UpdateItem(string itemID, Item item);
        public bool UpdateItems(Dictionary<string, Item> items);
        public bool DeleteItem(string itemID);
        public bool DeleteItems(Item item);
    }
}
