using CommonServiceLocator;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace TechgardenWPFTest.Helpers
{
    public class BaseViewModel : BindableBase , INavigationAware
    {
        public readonly IEventAggregator _eventAggregator;
        public readonly IUnityContainer _container;
        public BaseViewModel()
        {
            _container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
        }

        private void ShowError()
        {
           
        }
        private string _errorMsg;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { SetProperty(ref _errorMsg , value); }
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            _eventAggregator.GetEvent<ErrorMessage>().Publish(""); // Cleaning error message
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
