using ActionRpg.Models.Interfaces;
using ActionRpg.Models.ShopModels;

namespace ActionRpg.Server.GameServer.Items
{
    /// <summary>
    /// Server Item Datastore. Handles server side logic for items
    /// </summary>
    public class ItemDatastore : IItem
    {
        public bool CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItems(Item[] items)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(string itemID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(string itemID)
        {
            throw new NotImplementedException();
        }

        public Item[] GetItems(string[] itemID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(string itemID, Item item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItems(Dictionary<string, Item> items)
        {
            throw new NotImplementedException();
        }
    }
}
