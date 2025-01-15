using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenShare.Models;
using OpenShare.Constants;
using OpenShare.Commands;
using OpenShare.Network;
namespace OpenShare.ViewModels
{
    class MakeDrawerViewModel:ViewModelBase
    {
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

        private List<string> _privacies = Enums.GetEnumAsStringList(Enums.VALID_ENUMS.PRIVACY);
        private List<string> _layouts = Enums.GetEnumAsStringList(Enums.VALID_ENUMS.LAYOUT);

        public IEnumerable<string> Privacies => _privacies;
        private string privacy;
        public string Privacy
        {
            get
            {
                return privacy;
            }
            set
            {
                privacy = value;
                OnPropertyChanged(nameof(Privacy));
            }
        }

        public IEnumerable<string> Layouts => _layouts;
        private string layout;
        public string Layout
        {
            get
            {
                return layout;
            }
            set
            {
                layout = value;
                OnPropertyChanged(nameof(Layout));
            }
        }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }
        public UpdateViewCommand UpdateViewCommand { get; }
        public NetworkController Nc { get; }
        public MainViewModel ViewModel { get; }

        public MakeDrawerViewModel(NetworkController nc, MainViewModel viewModel)
        {
            AddCommand = new MakeDrawerCommand(this);
            CancelCommand = new UpdateViewCommand(nc, viewModel);
            UpdateViewCommand = new UpdateViewCommand(nc, viewModel);
            Nc = nc;
            ViewModel = viewModel;
        }  
    }
}
