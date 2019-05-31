using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Xamarin.Forms;

using TodoList.ViewModels.Abstract;
using TodoList.ViewModels.ItemViewModels;
using TodoList.Views;
using TodoList.Models;

namespace TodoList.ViewModels
{
    class NoteListViewModel: ViewModel
    {
        #region Properties
        
        /*
        public List<NoteListItemViewModel> NoteListItemViewModels
        {
            get
            {
                //List<NoteListItemViewModel> noteListItemViewModels = new List<NoteListItemViewModel>();

            }
        }
        */

        #endregion Properties

        public NoteListViewModel()
        {
            NewNoteCommand = new Command(NewNoteCommand_Execute);
        }

        #region Commands

        public Command NewNoteCommand { get; private set; }

        private async void NewNoteCommand_Execute()
        {
            NotePage notePage = new NotePage();
            await App.Current.MainPage.Navigation.PushAsync(notePage);
        }
        

        #endregion Commands

        #region Methods

        public void OnAppearing()
        {
            OnPropertyChanged("NoteListItemViewModels");
        }

        #endregion Methods
    }
}
