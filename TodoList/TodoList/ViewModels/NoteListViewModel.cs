using System;
using System.Collections.Generic;
using System.Text;

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

        }
    }
}
