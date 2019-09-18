using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kanban.Models;
using Newtonsoft.Json;

namespace Kanban.Services.Api
{
    public class ApiService : IApiService
    {
        public async Task<CustomResponse<ActivityModel>> CreateActivity(ActivityModel activity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteActivity(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponse<ActivityModel>> GetActivity(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponse<List<ActivityModel>>> GetAllActivities()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://eafit.azurewebsites.net/tables/activities";
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                var result = await client.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    string data = await result.Content.ReadAsStringAsync();
                    var deserializedResponse = JsonConvert.DeserializeObject<List<ActivityModel>>(data);

                    return new CustomResponse<List<ActivityModel>>()
                    {
                        Response = result,
                        Data = deserializedResponse
                    };
                }
                else
                {
                    return new CustomResponse<List<ActivityModel>>()
                    {
                        Response = result
                    };
                }
            }
        }

        public async Task<CustomResponse<ActivityModel>> UpdateActivity(ActivityModel activity)
        {
            throw new NotImplementedException();
        }
    }
}
