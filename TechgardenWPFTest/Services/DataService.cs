using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechgardenWPFTest.Models;

namespace TechgardenWPFTest.Services
{
    public class DataService : IDataService
    {
        private readonly IApiClient _apiClient;

        public DataService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            var uri = _apiClient.CreateRequestUri("map", "objectType=VEHICLE");
            var response = await _apiClient.GetAsync<ApiResponse>(uri);
            return response.Vehicles;
        }
    }
}
