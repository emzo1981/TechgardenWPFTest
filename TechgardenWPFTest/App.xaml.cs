using TechgardenWPFTest.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Prism.Unity;
using TechgardenWPFTest.Services;
using Unity;
using CommonServiceLocator;
using Telerik.Windows.Controls;

namespace TechgardenWPFTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //StyleManager.ApplicationTheme = new VistaTheme();
            containerRegistry.RegisterInstance<IDataService>(new DataService(new ApiClient()));
        }
        
    }
}
