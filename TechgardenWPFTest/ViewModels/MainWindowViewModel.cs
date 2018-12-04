using System;
using System.Collections.Generic;
using CommonServiceLocator;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using TechgardenWPFTest.Helpers;
using TechgardenWPFTest.Models;
using TechgardenWPFTest.Services;
using TechgardenWPFTest.Views;

namespace TechgardenWPFTest.ViewModels
{

    public class MainWindowViewModel : BaseViewModel
    {
        private readonly SubscriptionToken _token;

        private IRegionManager _regionManager;
        public MainWindowViewModel()
        {
            _regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            _regionManager.RegisterViewWithRegion("NaviRegion", typeof(NavigationView));
            _token = _eventAggregator.GetEvent<ErrorMessage>().Subscribe(ShowError);
        }

        private void ShowError(string errorMsg)
        {
            ErrorMsg = errorMsg;
        }      

        private string _title = "Techgarden Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
