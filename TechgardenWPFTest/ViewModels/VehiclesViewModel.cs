using CommonServiceLocator;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechgardenWPFTest.Helpers;
using TechgardenWPFTest.Models;
using TechgardenWPFTest.Services;

namespace TechgardenWPFTest.ViewModels
{
    public class VehiclesViewModel : BaseViewModel
    {
        readonly IDataService _dataService;
        public VehiclesViewModel()
        {
            _dataService = ServiceLocator.Current.GetInstance<IDataService>();
            GetApiData();

        }
        private async void GetApiData()
        {
            Vehicles = new List<Vehicle>();
            try {
                Vehicles = await _dataService.GetVehicles();
            }
            catch (Exception ex)
            {

            }
        }
        private IEnumerable<Vehicle> _vehicles;
        public IEnumerable<Vehicle> Vehicles
        {
            get { return _vehicles; }
            set { SetProperty(ref _vehicles, value); }
        }

     
    }
}
