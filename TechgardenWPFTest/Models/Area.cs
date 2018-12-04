using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechgardenWPFTest.Models
{
    public class Area
    {
        public Guid  Id { get; set; }
        public string  Name { get; set; }
        public IEnumerable<Location> Points { get; set; }
        public Color Color { get; set; }
    }
}
