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

        private DateTime? deadline;

        /// <summary>
        /// Deadline of note
        /// </summary>
        public DateTime? Deadline
        {
            get { return deadline; }
            set { deadline = value; OnPropertyChanged(); }
        }

        private DateTime minDeadline;

        /// <summary>
        /// Minimal deadline
        /// </summary>
        public DateTime MinDeadline
        {
            get { return minDeadline; }
            private set { minDeadline = value; OnPropertyChanged(); }
        }

        private bool deadlineEnable;

        /// <summary>
        /// Deadline of note
        /// </summary>
        public bool DeadlineEnable
        {
            get { return deadlineEnable; }
            set { deadlineEnable = value; OnPropertyChanged(); }
        }

        #endregion Properties

        public NoteViewModel()
        {
            //init commands
            SaveCommand = new Command(SaveCommand_Execute);

            //init props
            Title = "";
            Description = "";
            Deadline = DateTime.Now;
            DeadlineEnable = false;
            MinDeadline = DateTime.Now;
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

            //setup note model object
            Note note = new Note();
            note.Title = Title;
            note.Description = Description;
            note.Done = false;
            if (DeadlineEnable)
            {
                note.Deadline = Deadline;
            }
            else
            {
                note.Deadline = null;
            }

            //reset props
            Title = "";
            Description = "";
            Deadline = DateTime.Now;
            DeadlineEnable = false;

            //save note
            NotesContainer.AddNote(note);
        }

        #endregion Commands
    }
}
