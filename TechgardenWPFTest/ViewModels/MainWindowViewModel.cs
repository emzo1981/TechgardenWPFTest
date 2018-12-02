using System;
using System.Collections.Generic;
using Prism.Mvvm;
using TechgardenWPFTest.Models;
using TechgardenWPFTest.Services;

namespace TechgardenWPFTest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IDataService _dataService;
        public MainWindowViewModel(IDataService dataService)
        {
            _dataService = dataService;
            GetApiData();
        }

        private async void GetApiData()
        {
            Vehicles = await _dataService.GetVehicles();
        }
        private IEnumerable<Vehicle> _vehicles;
        public IEnumerable<Vehicle> Vehicles
        {
            get { return _vehicles; }
            set { SetProperty(ref _vehicles, value); }
        }

        private string _title = "Techgarden Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
