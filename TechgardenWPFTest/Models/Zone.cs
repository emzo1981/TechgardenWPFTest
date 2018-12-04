using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechgardenWPFTest.Models
{
    public class Zone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Area> AllowedAreas { get; set; }
        public IEnumerable<Area> ExcludedAreas { get; set; }

    }
}
