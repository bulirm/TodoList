using System;
using System.Collections.Generic;
using System.Text;

using TodoList.ViewModels.Abstract;

namespace TodoList.ViewModels
{
    class NoteViewModel: ViewModel
    {
        #region properties

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        #endregion properties

        public NoteViewModel()
        {

        }
    }
}
