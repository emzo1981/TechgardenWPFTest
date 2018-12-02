using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechgardenWPFTest.Models;

namespace TechgardenWPFTest.Services
{
    public class ApiResponse
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
