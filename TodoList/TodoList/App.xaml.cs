﻿using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TodoList.Views;
using TodoList.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            //MainPage = new NavigationPage(new NoteListPage());

            TabbedPage myTabbedPage = new MyTabbedPage();
            MainPage = myTabbedPage;
        }
        ~App()
        {
            Task.Run(async () =>
            {
                await NotesContainer.Destroy();
            }).Wait();
        }

        protected override async void OnStart()
        {
            await NotesContainer.Initialize();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
