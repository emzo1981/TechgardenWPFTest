using CommonServiceLocator;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
        private IEnumerable<Vehicle> VehiclesList = new List<Vehicle>();
        public VehiclesViewModel()
        {
            _dataService = ServiceLocator.Current.GetInstance<IDataService>();
            InitComboboxesData();
            GetApiData();

        }
        private async void InitComboboxesData()
        {
            var apiFiltersResponse = await _dataService.GetFilters();

            foreach (KeyValuePair<Guid, string> vehicleModel in apiFiltersResponse.Filters.VEHICLE_MODEL)
            {                
                VehicleModels.Add(new VehicleModel() { Id = vehicleModel.Key, Name = vehicleModel.Value });
            }

            foreach (KeyValuePair<string, string> vehicleModel in apiFiltersResponse.Filters.VEHICLE_STATUS)
            {
                VehicleStatuses.Add(vehicleModel.Key);
            }        

        }

        private async void GetApiData()
        {
           
            try {
                VehiclesList = await _dataService.GetVehicles();           
            }
            catch (HttpRequestException ex)
            {
                _eventAggregator.GetEvent<ErrorMessage>().Publish(ex.Message);

            }
            Vehicles = new ObservableCollection<Vehicle>(VehiclesList);
        }
        private void FilterResults()
        {
            
            if (SelectedVehicleModel != null && !string.IsNullOrEmpty(SelectedVehicleModel.Name) && !string.IsNullOrEmpty(SelectedVehicleStatus))
                Vehicles = new ObservableCollection<Vehicle>(VehiclesList.Where(x => x.Status.ToLower().Equals(SelectedVehicleStatus.ToLower()) && x.Name.ToLower().Equals(SelectedVehicleModel.Name.ToLower())));
            else if (SelectedVehicleModel != null && !string.IsNullOrEmpty(SelectedVehicleModel.Name) && string.IsNullOrEmpty(SelectedVehicleStatus))
                Vehicles = new ObservableCollection<Vehicle>(VehiclesList.Where(x => x.Name.ToLower().Equals(SelectedVehicleModel.Name.ToLower())));
            else if (SelectedVehicleModel == null || string.IsNullOrEmpty(SelectedVehicleModel.Name) && !string.IsNullOrEmpty(SelectedVehicleStatus))
                Vehicles = new ObservableCollection<Vehicle>(VehiclesList.Where(x => x.Status.ToLower().Equals(SelectedVehicleStatus.ToLower())));
            else
                Vehicles = new ObservableCollection<Vehicle>(VehiclesList);        

        }

        private ObservableCollection<Vehicle> _vehicles = new ObservableCollection<Vehicle>();
        public ObservableCollection<Vehicle> Vehicles
        {
            get { return _vehicles; }
            set { SetProperty(ref _vehicles, value); }
        }
       

        private ObservableCollection<VehicleModel> _vehicleModels = new ObservableCollection<VehicleModel>();
        public ObservableCollection<VehicleModel> VehicleModels
        {
            get { return _vehicleModels; }
            set { SetProperty(ref _vehicleModels, value); }
        }
        private VehicleModel _selectedVehicleModel;
        public VehicleModel SelectedVehicleModel
        {
            get { return _selectedVehicleModel; }
            set { SetProperty(ref _selectedVehicleModel , value);
                FilterResults();
            }
        }

        private ObservableCollection<string> _vehicleStatuses = new ObservableCollection<string>();
        public ObservableCollection<string> VehicleStatuses
        {
            get { return _vehicleStatuses; }
            set { SetProperty(ref _vehicleStatuses, value); }
        }

        private string _selectedVehicleStatus = "";
        public string SelectedVehicleStatus
        {
            get { return _selectedVehicleStatus; }
            set {
                SetProperty(ref _selectedVehicleStatus , value);
                FilterResults();
            }
        }



    }
}
