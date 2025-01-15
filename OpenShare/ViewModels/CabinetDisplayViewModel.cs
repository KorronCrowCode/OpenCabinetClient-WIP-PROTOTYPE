using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Shell;
using OpenShare.Commands;
using OpenShare.Models;
using OpenShare.Network;
using OpenShare.ViewModels.ComponentViewModels;

namespace OpenShare.ViewModels
{
    class CabinetDisplayViewModel : ViewModelBase
    {

        private readonly ObservableCollection<DrawerViewModel> _drawerViewModels;
        public IEnumerable<DrawerViewModel>? Drawers => _drawerViewModels;
        public ICommand GoToMakeDrawerCommand { get; }
        public ICommand UpdateViewCommand { get; }
        
        public NetworkController Nc { get; }
        public MainViewModel ViewModel { get; }

        public CabinetDisplayViewModel(NetworkController nc, MainViewModel viewModel)
        {
          
            _drawerViewModels = []; //init
            Nc = nc;
            ViewModel = viewModel;

            GoToMakeDrawerCommand = new UpdateViewCommand(nc, viewModel);
            UpdateViewCommand = new UpdateViewCommand(nc, viewModel);

            UpdateDrawers();


            
        }

        private void UpdateDrawers()
        {
            _drawerViewModels.Clear();

            foreach(Drawer drawer in Nc.GetValidDrawers("admin"))
            {
                DrawerViewModel drawerViewModel = new DrawerViewModel(drawer,Nc, ViewModel);
                _drawerViewModels.Add(drawerViewModel);
            }
        }


    }
}
