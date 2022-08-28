using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionRpg.Server.GameServer.Interfaces
{
    public interface IDatastore
    {
        public bool SaveToDatastore<T>(T item);
        public bool SaveListToDatastore<T>(T[] items);
        public bool UpdateInDatastore<T>(string key, T item);
        public bool UpdateListInDatastore<T>(Dictionary<string, T> items);
        public T GetFromDatastore<T>(string key);
        public T[] GetListFromDatastore<T>(string[] keys);
        public bool DeleteFromDatastore(string key);
        public Tuple<string, bool> DeleteListFromDatastore(string[] keys);
    }
}
