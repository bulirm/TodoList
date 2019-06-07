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
        #region Fields

        private NotesContainer notesContainer;

        #endregion Fields

        #region Properties

        
        public List<NoteListItemViewModel> NoteListItemViewModels
        {
            get
            {
                List<NoteListItemViewModel> noteListItemViewModels = new List<NoteListItemViewModel>();
                foreach (Note note in notesContainer.Notes)
                {
                    NoteListItemViewModel noteListItemViewModel = new NoteListItemViewModel(note);
                    noteListItemViewModels.Add(noteListItemViewModel);
                }
                return noteListItemViewModels;
            }
        }

        #endregion Properties

        public NoteListViewModel()
        {
            notesContainer = new NotesContainer();
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

        #endregion Methods
    }
}
