using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechgardenWPFTest.Models;
using TechgardenWPFTest.Services;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        public const string BAD_URI_STRING = "https://dev.vozilla.pl1/api-client-mobile/";
        public const string GOOD_URI_STRING = "https://dev.vozilla.pl/api-client-mobile/";
        private ApiClient _apiClient;
        private DataService _dataService; 
        public UnitTest()
        {
            _apiClient = new ApiClient();
            _apiClient.BaseEndpoint = new Uri(GOOD_URI_STRING);
            _dataService = new DataService(_apiClient);

        }
        [TestMethod]
        public async Task GetVehicles_SuccessRespond()
        {
            var vehciles = await _dataService.GetVehicles();
            Assert.IsInstanceOfType(vehciles, typeof(IEnumerable<Vehicle>));
        }
        [TestMethod]
        public async Task GetParkings_SuccessRespond()
        {
            var parkings = await _dataService.GetParkings();
            Assert.IsInstanceOfType(parkings, typeof(IEnumerable<Parking>));
        }
        [TestMethod]
        public async Task GetZones_SuccessRespond()
        {
            var zones = await _dataService.GetZones();
            Assert.IsInstanceOfType(zones, typeof(IEnumerable<Zone>));
        }

        [TestMethod]
        public async Task GetFilters_SuccessRespond()
        {
            var filters = await _dataService.GetFilters();
            Assert.IsInstanceOfType(filters, typeof(ApiFiltersResponse));
        }
        [TestMethod]
        [DataRow("map", "objectType=VEHICLE", "https://dev.vozilla.pl1/api-client-mobile/")]
        [DataRow("wrongMethod","", "https://dev.vozilla.pl1/")]
        [DataRow("map2", "objectType=VEHICLE", "https://dev.vozilla.pl1/api-client-mobile/")]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task ApiClient_BadApiUri(string apiMethodName,string objectType, string badUri)
        {
            _apiClient.BaseEndpoint = new Uri(badUri);

            var uri = _apiClient.CreateRequestUri(apiMethodName, objectType);
            var response = await _apiClient.GetAsync<ApiResponse>(uri);
            _apiClient.BaseEndpoint = new Uri(GOOD_URI_STRING);
        }
        [TestMethod]
        [DataRow("map", "objectType=VEHICLE")]      
        public async Task ApiClient_GoodApiUri(string apiMethodName, string objectType)
        {
            var uri = _apiClient.CreateRequestUri(apiMethodName, objectType);
            var response = await _apiClient.GetAsync<ApiResponse>(uri);

        }
    }
}
