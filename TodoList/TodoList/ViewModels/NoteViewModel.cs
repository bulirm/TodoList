using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using TodoList.ViewModels.Abstract;
using TodoList.Views;
using TodoList.Models;

namespace TodoList.ViewModels
{
    class NoteViewModel: ViewModel
    {
        #region Fields



        #endregion Fields

        #region Properties

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

        #endregion Properties

        public NoteViewModel()
        {
            SaveCommand = new Command(SaveCommand_Execute);
        }

        #region Commands
        

        public Command SaveCommand { get; private set; }

        private void SaveCommand_Execute()
        {
            
        }

        #endregion Commands
    }
}
