using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechgardenWPFTest.Models
{
    public class Filter
    {
        public Dictionary<Guid,string> VEHICLE_MODEL { get; set; }
        public Dictionary<string, string> VEHICLE_STATUS { get; set; }
    }
}
