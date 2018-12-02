using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechgardenWPFTest.Helpers;
using TechgardenWPFTest.Models;

namespace TechgardenWPFTest.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {

        public NavigationViewModel()
        {
            NavigationTree = new List<NavigationNode>();
            NavigationTree.Add(new NavigationNode() { Name = "Football" });
            NavigationTree.Add(new NavigationNode() { Name = "Tennis" });
            NavigationTree.Add(new NavigationNode() { Name = "Cycling" });
        }

        private List<NavigationNode> _navigationTree;
        public List<NavigationNode> NavigationTree
        {
            get { return _navigationTree; }
            set { SetProperty(ref _navigationTree, value); }
        }
        
        private object _selectedNode;
        public object SelectedNode
        {
            get { return _selectedNode; }
            set { SetProperty(ref _selectedNode , value); }
        }

    }
    
}
