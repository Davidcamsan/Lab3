using System;
using System.Collections.Generic;
using Lab3.ViewModels;

using Xamarin.Forms;

namespace Lab3.Views
{
    public partial class LogInView : ContentPage
    {
        public LogInView()
        {
            InitializeComponent();
            BindingContext = UsuarioViewModel.GetInstance();
        }
    }
}
