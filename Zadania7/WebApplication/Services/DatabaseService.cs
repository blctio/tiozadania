using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Models;

namespace WebApplication9.Services
{
    public class DatabaseStorage : IValuesService
    {
        List<Item> _localList = new List<Item>();

        public DatabaseStorage()
        {
            _localList.Add(new Item() { Id = 1, Value = "Baza1" });
            _localList.Add(new Item() { Id = 1, Value = "Baza2" });
            _localList.Add(new Item() { Id = 1, Value = "Baza3" });
            _localList.Add(new Item() { Id = 1, Value = "Baza4" });
        }

        public Models.Item[] GetValues()
        {
            return _localList.ToArray();
        }

        public Models.Item Get(int id)
        {
            return _localList.FirstOrDefault(x => x.Id == id);
        }

        public int Add(Models.Item item)
        {
            var maxId = _localList.Max(x => x.Id);
            item.Id = ++maxId;
            this._localList.Add(item);
            return item.Id;
        }

        public void Delete(int id)
        {
            var item = _localList.FirstOrDefault(x => x.Id == id);
            if (item != null)
                _localList.Remove(item);
        }
    }
}