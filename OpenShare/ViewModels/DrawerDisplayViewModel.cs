using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Commands;
using OpenShare.Models;
using OpenShare.ViewModels.ComponentViewModels;
using System.Windows.Input;
using OpenShare.Network;

namespace OpenShare.ViewModels
{
    public class DrawerDisplayViewModel : ViewModelBase
    {
        public readonly string _drawerName;

        private readonly ObservableCollection<ItemViewModel> _itemViewModels;
        public IEnumerable<ItemViewModel> Notes => _itemViewModels;
        public ICommand MakeNoteCommand { get; }

        public ICommand UpdateViewCommand { get; }
        public NetworkController Nc { get; }
        public MainViewModel ViewModel { get; }

        public DrawerDisplayViewModel(NetworkController nc, MainViewModel viewModel)
        {
            Nc = nc;
            ViewModel = viewModel;
            _itemViewModels = []; //init
            _drawerName = nc.drawerToAccess;
            MakeNoteCommand = new UpdateViewCommand(nc, viewModel);
            UpdateViewCommand = new UpdateViewCommand(nc, viewModel);

            UpdateItems();

           
            
        }

        private void UpdateItems()
        {
            _itemViewModels.Clear();
            Console.WriteLine(Nc.drawerToAccess);
            foreach (Item item in Nc.GetItems(Nc.drawerToAccess, "admin"))
            {
                ItemViewModel itemViewModel = new ItemViewModel(item);
                _itemViewModels.Add(itemViewModel);
            }
        }

        private List<ItemViewModel> GetConvertedItemList(Drawer drawer)
        {
            List<ItemViewModel> tempList = [];
            foreach (Item i in drawer.GetAllItems()) 
            {
                ItemViewModel iVM = new(i);
                tempList.Add(iVM);
            }

            return tempList;
        }
    }
}
