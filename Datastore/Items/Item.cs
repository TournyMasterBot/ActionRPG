using ActionRpg.Models.Interfaces;

namespace ActionRpg.Datastore.Items
{
    public class Item : IItem
    {
        public bool CreateItem(Models.ShopModels.Item item)
        {
            throw new NotImplementedException();
        }

        public bool CreateItems(Models.ShopModels.Item[] items)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFromDatastore(string key)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(string itemID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(Models.ShopModels.Item item)
        {
            throw new NotImplementedException();
        }

        public Tuple<string, bool> DeleteListFromDatastore(string[] keys)
        {
            throw new NotImplementedException();
        }

        public T GetFromDatastore<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Models.ShopModels.Item GetItem(string itemID)
        {
            throw new NotImplementedException();
        }

        public Models.ShopModels.Item[] GetItems(string[] itemID)
        {
            throw new NotImplementedException();
        }

        public T[] GetListFromDatastore<T>(string[] keys)
        {
            throw new NotImplementedException();
        }

        public bool SaveListToDatastore<T>(T[] items)
        {
            throw new NotImplementedException();
        }

        public bool SaveToDatastore<T>(T item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInDatastore<T>(string key, T item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(string itemID, Models.ShopModels.Item item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItems(Dictionary<string, Models.ShopModels.Item> items)
        {
            throw new NotImplementedException();
        }

        public bool UpdateListInDatastore<T>(Dictionary<string, T> items)
        {
            throw new NotImplementedException();
        }
    }
}
