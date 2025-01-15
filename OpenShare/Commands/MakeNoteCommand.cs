using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenShare.Constants;
using OpenShare.Exceptions;
using OpenShare.Models;
using OpenShare.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace OpenShare.Commands
{
    class MakeNoteCommand : CommandBase
    {
        private readonly MakeNoteViewModel _makeNoteViewModel;

        public MakeNoteCommand(MakeNoteViewModel makeNoteViewModel)
        {
            _makeNoteViewModel = makeNoteViewModel;
            _makeNoteViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return
                !string.IsNullOrEmpty(_makeNoteViewModel.Name)
                && !string.IsNullOrEmpty(_makeNoteViewModel.TextData)
                && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            Note note = new Note { Name = _makeNoteViewModel.Name, TextData = _makeNoteViewModel.TextData};
            try
            {
                _makeNoteViewModel.Nc.AddItem(note, _makeNoteViewModel.Nc.drawerToAccess, "NOTE");

                ICommand updateView = new UpdateViewCommand(_makeNoteViewModel.Nc, _makeNoteViewModel.ViewModel);
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
            if (e.PropertyName == nameof(MakeDrawerViewModel.Name) ||
               e.PropertyName == nameof(MakeDrawerViewModel.Layout) ||
               e.PropertyName == nameof(MakeDrawerViewModel.Privacy))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
