using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Models;
using OpenShare.ViewModels;
using OpenShare.Constants;
using OpenShare.Exceptions;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;

namespace OpenShare.Commands
{
    class MakeDrawerCommand : CommandBase
    {
        private MakeDrawerViewModel _makeDrawerViewModel;

        public MakeDrawerCommand(MakeDrawerViewModel createDrawerViewModel)
        {
            _makeDrawerViewModel = createDrawerViewModel;
            _makeDrawerViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return 
                !string.IsNullOrEmpty(_makeDrawerViewModel.Name) 
                && _makeDrawerViewModel.Layout!=null
                && _makeDrawerViewModel.Privacy != null
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            Drawer drawer = new Drawer(
                (Enums.LAYOUT)Enums.StringToLayoutEnum(_makeDrawerViewModel.Layout),
                (Enums.PRIVACY)Enums.StringToPrivacyEnum(_makeDrawerViewModel.Privacy),
                _makeDrawerViewModel.Name,
                "admin"
                );
            try
            {
                _makeDrawerViewModel.Nc.AddDrawer(drawer);
                ICommand updateView = new UpdateViewCommand(_makeDrawerViewModel.Nc, _makeDrawerViewModel.ViewModel);
                updateView.Execute(parameter);
            }
            catch (DrawerConflictException)
            {
                MessageBox.Show("This Name Is Already In Use", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }        
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeDrawerViewModel.Name) ||
               e.PropertyName == nameof(MakeDrawerViewModel.Layout) ||
               e.PropertyName == nameof(MakeDrawerViewModel.Privacy))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
