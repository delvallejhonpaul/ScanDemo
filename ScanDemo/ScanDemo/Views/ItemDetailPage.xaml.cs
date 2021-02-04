using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ScanDemo.Models;
using ScanDemo.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ScanDemo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel, string Balance)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            if (Convert.ToInt32(Balance.Replace("Account Balance: ", "")) < Convert.ToInt32(viewModel.Price))
            {
                btnSubmit.IsEnabled = false;
                DisplayAlert("Unsufficient Balance", "Oh! you have unsufficient balance.", "Close");
            }
            else
            {
                btnSubmit.IsEnabled = true;
            }

        }

        public ItemDetailPage()
        {
            
        }

        async void OnSubmit(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.IsEnabled = false;
                // the rest of the logic
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://delvalle-001-site2.btempurl.com/Home/Pay?username=" + Application.Current.Properties["Username"] + "&item="+ viewModel.Title + "&price="+ Convert.ToInt32(viewModel.Price) +"");
            viewModel.Balance = "Account Balance: " + JsonConvert.DeserializeObject<string>(response);
            DisplayAlert("Success", "Transaction successful", "Close");
            Application.Current.MainPage = new NavigationPage(new MainPage());

        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}