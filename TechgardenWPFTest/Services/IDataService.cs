using System.Collections.Generic;
using System.Threading.Tasks;
using TechgardenWPFTest.Models;

namespace TechgardenWPFTest.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Vehicle>> GetVehicles();
    }
}