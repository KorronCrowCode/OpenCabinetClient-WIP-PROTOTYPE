using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenShare.Commands;
using OpenShare.Models;
using OpenShare.Network;

namespace OpenShare.ViewModels.ComponentViewModels
{
    public class DrawerViewModel(Drawer drawer, NetworkController nc, MainViewModel viewModel) : ViewModelBase
    {
        private readonly Drawer _drawer = drawer;
        public string Name => _drawer.Name;
        public string Privacy => _drawer._privacy.ToString();
        public string Layout => _drawer._layout.ToString();
        public List<ItemViewModel> Items => AddConvertedItemList(_drawer);

        public ICommand GoToDrawerCommand { get; } = new GoToDrawerCommand(nc, viewModel);
        private List<ItemViewModel> AddConvertedItemList(Drawer drawer)
        {
            List<ItemViewModel> tempList = [];
            foreach(Item i in drawer._items)
            {
                ItemViewModel iVM = new(i);
                tempList.Add(iVM);
            }
               
            return tempList;
        }
    }
}
