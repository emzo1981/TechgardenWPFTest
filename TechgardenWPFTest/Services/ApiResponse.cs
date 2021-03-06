﻿using System;
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
        public IEnumerable<Parking> Parking { get; set; }
        public IEnumerable<Zone> Zones { get; set; }
    }
}
