using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechgardenWPFTest.Models
{
    public class Parking
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public Address Address { get; set; }
        public int SpacesCount { get; set; }
        public int AvailableSpacesCount { get; set; }
        public IEnumerable<string> Chargers { get; set; }
        public Color Color { get; set; }
    }
}
