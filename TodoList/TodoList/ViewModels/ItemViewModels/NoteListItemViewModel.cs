using System;
using System.Collections.Generic;
using System.Text;

using TodoList.ViewModels.Abstract;
using TodoList.Models;

using Xamarin.Forms;
using System.Diagnostics;

namespace TodoList.ViewModels.ItemViewModels
{
    class NoteListItemViewModel: ViewModel
    {
        #region Fields

        private Note note;

        #endregion Fields

        #region Properties

        public string Title
        {
            get { return note.Title; }
        }

        public string Description
        {
            get { return note.Description; }
        }

        #endregion Properties

        public NoteListItemViewModel(Note note)
        {
            this.note = note;
            DeleteCommand = new Command(DeleteCommand_Execute);
            MarkAsDoneCommand = new Command(MarkAsDoneCommand_Execute);
        }

        #region Commands

        public Command DeleteCommand { get; private set; }

        private void DeleteCommand_Execute()
        {
            NotesContainer.DeleteNote(note);
        }

        public Command MarkAsDoneCommand { get; private set; }

        private void MarkAsDoneCommand_Execute()
        {
            NotesContainer.MarkAsDone(note);
        }

        #endregion Commands
    }
}
