using System.Collections.Generic;
using System.Threading.Tasks;
using TechgardenWPFTest.Models;

namespace TechgardenWPFTest.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<IEnumerable<Parking>> GetParkings();
        Task<IEnumerable<Zone>> GetZones();
        Task<ApiFiltersResponse> GetFilters();
    }
}