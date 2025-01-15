using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Commands;
using OpenShare.Constants;
using OpenShare.Models;
using System.Windows.Input;
using OpenShare.Network;

namespace OpenShare.ViewModels
{
    class MakeNoteViewModel : ViewModelBase
    {
        private readonly string drawerName;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string textData;
        public string TextData
        {
            get
            {
                return textData;
            }
            set
            {
                textData = value;
                OnPropertyChanged(nameof(TextData));
            }
        }


        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }
        public UpdateViewCommand UpdateViewCommand { get; }
        public NetworkController Nc { get; }
        public MainViewModel ViewModel { get; }

        public MakeNoteViewModel(NetworkController nc, MainViewModel viewModel)
        {
            Console.WriteLine(nc.drawerToAccess);
            AddCommand = new MakeNoteCommand(this);
            CancelCommand = new UpdateViewCommand(nc, viewModel);
            UpdateViewCommand = new UpdateViewCommand(nc, viewModel);
            Nc = nc;
            ViewModel = viewModel;
        }
    }
}
