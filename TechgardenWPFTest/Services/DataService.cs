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
        public async Task<IEnumerable<Parking>> GetParkings()
        {
            var uri = _apiClient.CreateRequestUri("map", "objectType=PARKING");
            var response = await _apiClient.GetAsync<ApiResponse>(uri);
            return response.Parking;
        }
        public async Task<IEnumerable<Zone>> GetZones()
        {
            var uri = _apiClient.CreateRequestUri("map", "objectType=ZONE");
            var response = await _apiClient.GetAsync<ApiResponse>(uri);
            return response.Zones;
        }
        public async Task<ApiFiltersResponse> GetFilters()
        {
            var uri = _apiClient.CreateRequestUri("map/filters", "");
            var response = await _apiClient.GetAsync<ApiFiltersResponse>(uri);
            return response;
        }

    }
}
