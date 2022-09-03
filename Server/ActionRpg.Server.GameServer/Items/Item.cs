using ActionRpg.Models.DatastoreCoreModels;
using ActionRpg.Models.Interfaces;
using ActionRpg.Models.ItemModels;
using ActionRpg.Server.GameServer.Managers;

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

        public async Task<Item?> GetItem(string itemID)
        {
            var item = await ApplicationState.App.Datastore.GetFromDatastore<Item>(new TableGetInput()
            {
                TableName = "items",
                Key = itemID,
            });
            return item;
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
