﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}