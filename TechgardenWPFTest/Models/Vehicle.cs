using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechgardenWPFTest.Models
{
    public class Vehicle : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlatesNumber { get; set; }
        public string SideNumber { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public int RangeKm { get; set; }
        public int BatteryLevelPct { get; set; }
        public DateTimeOffset? ReservationEnd { get; set; }
        public string Status { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public string Promotion { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

    }
}
