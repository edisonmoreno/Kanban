using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Kanban.Models;
using SQLite;

namespace Kanban.Services.LocalDatabase
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
        private readonly SQLiteAsyncConnection _connection;

        public LocalDatabaseService()
        {
            _connection = new SQLiteAsyncConnection(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "localdb.db3"));
        }

        public async Task CreateActivity(ActivityModel activity)
        {
            await _connection.InsertAsync(activity);
        }

        public async Task DeleteActivity(string id)
        {
            await _connection.DeleteAsync<ActivityModel>(id);
        }

        public async Task<ActivityModel> GetActivity(string id)
        {
            return await _connection.GetAsync<ActivityModel>(id);
        }

        public async Task<List<ActivityModel>> GetAllActivities()
        {
            return await _connection.Table<ActivityModel>().ToListAsync();
        }

        public async Task Initialize()
        {
            await _connection.CreateTableAsync<ActivityModel>();
        }

        public async Task UpdateActivity(ActivityModel activity)
        {
            await _connection.UpdateAsync(activity);
        }
    }
}
