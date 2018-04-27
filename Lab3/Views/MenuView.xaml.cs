using System;
using System.Collections.Generic;
using Lab3.ViewModels;


using Xamarin.Forms;

namespace Lab3.Views
{
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();
            BindingContext = UsuarioViewModel.GetInstance();
        }
    }
}
