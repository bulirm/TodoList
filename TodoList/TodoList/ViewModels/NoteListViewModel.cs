using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using TodoList.Views;

using TodoList.ViewModels.Abstract;

namespace TodoList.ViewModels
{
    class NoteListViewModel: ViewModel
    {
        #region properties

        private List<NoteViewModel> noteViewModels;

        public List<NoteViewModel> NoteViewModels
        {
            get { return noteViewModels; }
            set { noteViewModels = value; OnPropertyChanged(); }
        }

        #endregion properties

        public NoteListViewModel()
        {
            NewNoteCommand = new Command(NewNoteCommand_Execute);
        }

        #region commands

        public Command NewNoteCommand { get; private set; }

        private void NewNoteCommand_Execute()
        {
            App.Current.MainPage = new NotePage();
        }

        #endregion commands
    }
}
