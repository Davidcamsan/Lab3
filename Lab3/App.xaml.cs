using System;
using System.Collections.Generic;
using Lab3.Views;
using Xamarin.Forms;

namespace Lab3
{
    public partial class App : Application
    {
        public App()
        {
			InitializeComponent();
			App.Current.MainPage = new MapView();

        }
    }
}
