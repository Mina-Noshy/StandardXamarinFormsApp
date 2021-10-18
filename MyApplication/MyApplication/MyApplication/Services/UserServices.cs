using MyApplication.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Services
{
    public class UserServices : IDataStore<User>
    {
        readonly SQLiteConnection db;
        readonly List<User> items;

        public UserServices()
        {
            db = App.context.Connection;
            items = db.Table<User>().ToList();
        }

        public async Task<bool> AddItemAsync(User item)
        {
            bool result = db.Insert(item) == 0 ? false : true;

            return await Task.FromResult(result);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            bool result = db.Delete<User>(id) == 0 ? false : true;
            return await Task.FromResult(result);
        }

        public async Task<User> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            bool result = db.Update(item) == 0 ? false : true;
            return await Task.FromResult(true);
        }
    }
}
