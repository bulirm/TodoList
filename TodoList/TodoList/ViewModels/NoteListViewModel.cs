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
    class NoteListViewModel: ViewModel
    {

        #region Properties
        
        public List<NoteListItemViewModel> NoteUndoneListItemViewModels
        {
            get
            {
                List<NoteListItemViewModel> noteListItemViewModels = new List<NoteListItemViewModel>();
                foreach (Note note in NotesContainer.Undone)
                {
                    NoteListItemViewModel noteListItemViewModel = new NoteListItemViewModel(note);
                    noteListItemViewModels.Add(noteListItemViewModel);
                }
                return noteListItemViewModels;
            }
        }

        public List<NoteListItemViewModel> NoteDoneListItemViewModels
        {
            get
            {
                List<NoteListItemViewModel> noteListItemViewModels = new List<NoteListItemViewModel>();
                foreach (Note note in NotesContainer.Done)
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
            NotesContainer.OnChanged += OnNoteAdded;
        }

        #region Methods

        private void OnNoteAdded(object sender, EventArgs e)
        {
            OnPropertyChanged("NoteUndoneListItemViewModels");
            OnPropertyChanged("NoteDoneListItemViewModels");
        }

        #endregion Methods
    }
}
