using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

using TodoList.ViewModels.Abstract;
using TodoList.Views;

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
            CancelCommand = new Command(CancelCommand_Execute);
            SaveCommand = new Command(SaveCommand_Execute);
        }

        #region commands

        public Command CancelCommand { get; private set; }

        private async void CancelCommand_Execute()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public Command SaveCommand { get; private set; }

        private void SaveCommand_Execute()
        {
            
        }

        #endregion commands
    }
}
