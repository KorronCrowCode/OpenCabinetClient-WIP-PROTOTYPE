using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenShare.Network;
using OpenShare.ViewModels;

namespace OpenShare.Commands
{
    class GoToDrawerCommand : ICommand
    {
        private NetworkController Nc { get; }
        private MainViewModel ViewModel { get; }

        public event EventHandler? CanExecuteChanged;

        public GoToDrawerCommand(NetworkController nc, MainViewModel viewModel)
        {
            Nc = nc;
            ViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Nc.drawerToAccess = parameter.ToString();
            var GoToDrawer = new UpdateViewCommand(Nc, ViewModel);
            GoToDrawer.Execute("DRAWER");
        }
    }
}
