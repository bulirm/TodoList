using System;
using System.Collections.Generic;
using System.Text;

using TodoList.ViewModels.Abstract;
using TodoList.Models;

using Xamarin.Forms;

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

        #endregion Properties

        public NoteListItemViewModel(Note note)
        {
            this.note = note;
        }
    }
}
