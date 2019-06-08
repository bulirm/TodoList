using System;
using System.Collections.Generic;
using System.Text;

using TodoList.ViewModels.Abstract;
using TodoList.Models;

using Xamarin.Forms;
using System.Diagnostics;

namespace TodoList.ViewModels.ItemViewModels
{
    /// <summary>
    /// This view-model connects ViewCell of ListView in View to Note model object.
    /// </summary>
    class NoteListItemViewModel: ViewModel
    {
        #region Fields

        /// <summary>
        /// Note model object
        /// </summary>
        private Note note;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Title of note
        /// </summary>
        public string Title
        {
            get { return note.Title; }
        }

        /// <summary>
        /// Description of note
        /// </summary>
        public string Description
        {
            get { return note.Description; }
        }

        #endregion Properties

        public NoteListItemViewModel(Note note)
        {
            this.note = note;
            //init commands
            DeleteCommand = new Command(DeleteCommand_Execute);
            MarkAsDoneCommand = new Command(MarkAsDoneCommand_Execute);
        }

        #region Commands

        public Command DeleteCommand { get; private set; }

        /// <summary>
        /// Delete note model
        /// </summary>
        private void DeleteCommand_Execute()
        {
            NotesContainer.DeleteNote(note);
        }
        
        public Command MarkAsDoneCommand { get; private set; }

        /// <summary>
        /// Mark note model as done
        /// </summary>
        private void MarkAsDoneCommand_Execute()
        {
            NotesContainer.MarkAsDone(note);
        }

        #endregion Commands
    }
}
