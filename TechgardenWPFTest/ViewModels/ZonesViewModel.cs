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
    public class ZonesViewModel : BaseViewModel
    {
        readonly IDataService _dataService;
        public ZonesViewModel()
        {
            _dataService = ServiceLocator.Current.GetInstance<IDataService>();
            GetApiData();

        }
        private async void GetApiData()
        {
            Zones = new ObservableCollection<Zone>();
            try {
                Zones = new ObservableCollection<Zone>(await _dataService.GetZones());
            }
            catch (HttpRequestException ex)
            {
                _eventAggregator.GetEvent<ErrorMessage>().Publish(ex.Message);
            }
        }
        private ObservableCollection<Zone> _zones;
        public ObservableCollection<Zone> Zones
        {
            get { return _zones; }
            set { SetProperty(ref _zones, value); }
        }

     
    }
}
