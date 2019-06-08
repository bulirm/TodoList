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

        #region Properties

        private string title;

        /// <summary>
        /// Title of note
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        private string description;

        /// <summary>
        /// Description of note
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        #endregion Properties

        public NoteViewModel()
        {
            //init commands
            SaveCommand = new Command(SaveCommand_Execute);

            //init props
            Title = "";
            Description = "";
        }

        #region Commands
        

        public Command SaveCommand { get; private set; }

        /// <summary>
        /// Save note with data in view-model properties
        /// </summary>
        private void SaveCommand_Execute()
        {
            if (Title == "")
            {
                App.Current.MainPage.DisplayAlert("Input issue", "Title must not be empty!", "Ok");
                return;
            }
            Note note = new Note();
            note.Title = Title;
            note.Description = Description;
            note.Done = false;
            Title = "";
            Description = "";
            NotesContainer.AddNote(note);
        }

        #endregion Commands
    }
}
