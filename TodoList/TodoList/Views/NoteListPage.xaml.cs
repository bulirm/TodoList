﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TodoList.ViewModels;

namespace TodoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteListPage : ContentPage
    {
        public NoteListPage()
        {
            InitializeComponent();
        }
    }
}