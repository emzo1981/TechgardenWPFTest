using CommonServiceLocator;
using Prism.Events;
using Prism.Mvvm;

namespace TechgardenWPFTest.Helpers
{
    public class BaseViewModel : BindableBase
    {
        public readonly IEventAggregator _eventAggregator;
        private readonly SubscriptionToken _token;
        public BaseViewModel()
        {
            _eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            _token = _eventAggregator.GetEvent<ErrorMessage>().Subscribe(ShowError);
        }

        private void ShowError()
        {
           
        }
    }
}
