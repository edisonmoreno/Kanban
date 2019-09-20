using Kanban.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Services.Api
{
    public interface IApiService
    {
        Task<CustomResponse<ActivityModel>> CreateActivity(ActivityModel activity);
        Task<CustomResponse<ActivityModel>> UpdateActivity(ActivityModel activity);
        Task<CustomResponse<ActivityModel>> DeleteActivity(string id);
        Task<CustomResponse<ActivityModel>> GetActivity(string id);
        Task<CustomResponse<List<ActivityModel>>> GetAllActivities();
    }
}
