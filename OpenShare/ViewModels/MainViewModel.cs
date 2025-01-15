using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using OpenShare.Commands;
using OpenShare.Models;
using OpenShare.Network;

namespace OpenShare.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NetworkController nc = new();
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { 
                _selectedViewModel = value; 
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public MainViewModel()
        {
            _selectedViewModel = new CabinetDisplayViewModel(nc, this);
        }

    }
}
