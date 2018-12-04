using CommonServiceLocator;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechgardenWPFTest.Helpers;
using TechgardenWPFTest.Models;
using TechgardenWPFTest.Views;

namespace TechgardenWPFTest.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private IRegionManager _regionManager;

        public NavigationViewModel()
        {
            _regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            NavigationTree = new List<NavigationNode>();
            NavigationTree.Add(new NavigationNode() { Name = "Pojazdy" });
            NavigationTree.Add(new NavigationNode() { Name = "Strefy" });
            NavigationTree.Add(new NavigationNode() { Name = "Parkingi" });
            _regionManager.RequestNavigate("ContentRegion", "VehiclesView");

        }

        private List<NavigationNode> _navigationTree;
        public List<NavigationNode> NavigationTree
        {
            get { return _navigationTree; }
            set { SetProperty(ref _navigationTree, value); }
        }
        
        private NavigationNode _selectedNode;
        public NavigationNode SelectedNode
        {
            get { return _selectedNode; }
            set { SetProperty(ref _selectedNode , value);
                InjectViewToRegion();
            }
        }
        private void InjectViewToRegion()
        {
            if (SelectedNode.Name.Equals("Pojazdy") )
            {
                _regionManager.RequestNavigate("ContentRegion", "VehiclesView");
            }
            else if (SelectedNode.Name.Equals("Strefy"))
            {
                _regionManager.RequestNavigate("ContentRegion", "ZonesView");
            }
            else if (SelectedNode.Name.Equals("Parkingi"))
            {
                _regionManager.RequestNavigate("ContentRegion", "ParkingView");

            }
        }
    }
    
}
