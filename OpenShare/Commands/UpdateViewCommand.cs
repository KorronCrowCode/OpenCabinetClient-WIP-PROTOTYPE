using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenShare.Network;
using OpenShare.ViewModels;

namespace OpenShare.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private NetworkController Nc;
        private MainViewModel ViewModel;

        public UpdateViewCommand(NetworkController nc, MainViewModel viewModel)
        {
            ViewModel = viewModel; 
            Nc = nc;
        }
        
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
            {
                Console.WriteLine("No param");
            }
            else
            {

            
                if (parameter.ToString().Equals("CABINET"))
                {
                    ViewModel.SelectedViewModel = new CabinetDisplayViewModel(Nc, ViewModel);
                }
                else if (parameter.ToString().Equals("ADD_DRAWER"))
                {
                    ViewModel.SelectedViewModel = new MakeDrawerViewModel(Nc, ViewModel);
                }
                else if (parameter.ToString().Equals("DRAWER"))
                {

                    ViewModel.SelectedViewModel = new DrawerDisplayViewModel(Nc, ViewModel);
                }
                else if (parameter.ToString().Equals("ADD_NOTE"))
                {
                    ViewModel.SelectedViewModel = new MakeNoteViewModel(Nc, ViewModel);
                }
            }

        }
    }
}
