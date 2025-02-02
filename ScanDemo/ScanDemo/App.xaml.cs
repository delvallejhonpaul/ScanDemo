﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScanDemo.Services;
using ScanDemo.Views;

namespace ScanDemo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<BalanceStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
