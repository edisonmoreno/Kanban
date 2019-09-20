using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Services.LocalDatabase
{
    public interface ILocalDatabaseService
    {
        Task Initialize();
        Task CreateActivity(ActivityModel activity);
        Task UpdateActivity(ActivityModel activity);
        Task DeleteActivity(string id);
        Task<ActivityModel> GetActivity(string id);
        Task<List<ActivityModel>> GetAllActivities();
    }
}
