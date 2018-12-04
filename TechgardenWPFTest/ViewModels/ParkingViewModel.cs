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
    public class ParkingViewModel : BaseViewModel
    {
        readonly IDataService _dataService;
        public ParkingViewModel()
        {
            _dataService = ServiceLocator.Current.GetInstance<IDataService>();
            GetApiData();

        }
        private async void GetApiData()
        {
            ParkingList = new ObservableCollection<Parking>();
            try {
                ParkingList = new ObservableCollection<Parking>(await _dataService.GetParkings());
            }
            catch (HttpRequestException ex)
            {
                _eventAggregator.GetEvent<ErrorMessage>().Publish(ex.Message);
            }
        }
        private ObservableCollection<Parking> _parkingList;
        public ObservableCollection<Parking> ParkingList
        {
            get { return _parkingList; }
            set { SetProperty(ref _parkingList, value); }
        }
        
     
    }
}
