using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ScanDemo.Models;
using ScanDemo.Views;
using ScanDemo.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;

namespace ScanDemo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            viewModel = new ItemsViewModel();
            OnSubmitAsync();

        }

        public async void OnSubmitAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://delvalle-001-site2.btempurl.com/Home/ListTransaction?username=" + Application.Current.Properties["Username"] + "");
            List<Transaction> item = JsonConvert.DeserializeObject<List<Transaction>>(response);
            lst.ItemsSource = item;
        }

    }
}