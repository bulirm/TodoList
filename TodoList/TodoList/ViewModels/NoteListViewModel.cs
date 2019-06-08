using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text;

using Xamarin.Forms;

using TodoList.ViewModels.Abstract;
using TodoList.ViewModels.ItemViewModels;
using TodoList.Views;
using TodoList.Models;

namespace TodoList.ViewModels
{
    /// <summary>
    /// Provides lists of data in models.
    /// </summary>
    class NoteListViewModel: ViewModel
    {

        #region Properties
        
        /// <summary>
        /// List of ItemViewModels holdin note models which done property is false.
        /// </summary>
        public List<NoteListItemViewModel> NoteUndoneListItemViewModels
        {
            get
            {
                //create new list
                List<NoteListItemViewModel> noteListItemViewModels = new List<NoteListItemViewModel>();
                foreach (Note note in NotesContainer.UndoneOrdered)
                {
                    //create and add viewmodel with model of note
                    NoteListItemViewModel noteListItemViewModel = new NoteListItemViewModel(note);
                    noteListItemViewModels.Add(noteListItemViewModel);
                }
                return noteListItemViewModels;
            }
        }

        /// <summary>
        /// List of ItemViewModels holdin note models which done property is true.
        /// </summary>
        public List<NoteListItemViewModel> NoteDoneListItemViewModels
        {
            get
            {
                //create new list
                List<NoteListItemViewModel> noteListItemViewModels = new List<NoteListItemViewModel>();
                foreach (Note note in NotesContainer.DoneOrdered)
                {
                    //create and add viewmodel with model of note
                    NoteListItemViewModel noteListItemViewModel = new NoteListItemViewModel(note);
                    noteListItemViewModels.Add(noteListItemViewModel);
                }
                return noteListItemViewModels;
            }
        }

        #endregion Properties

        public NoteListViewModel()
        {
            NotesContainer.OnChanged += OnNoteAdded;
        }

        #region Methods

        /// <summary>
        /// Make viewlists update data.
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event parameters</param>
        private void OnNoteAdded(object sender, EventArgs e)
        {
            OnPropertyChanged("NoteUndoneListItemViewModels");
            OnPropertyChanged("NoteDoneListItemViewModels");
        }

        #endregion Methods
    }
}
