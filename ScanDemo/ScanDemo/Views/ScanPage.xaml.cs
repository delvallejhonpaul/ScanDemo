using Newtonsoft.Json;
using ScanDemo.Models;
using ScanDemo.ViewModels;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace ScanDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        ScanViewModel viewModel;
        public bool IsScaned = false;
        public ScanPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ScanViewModel();
            OnSubmitAsync();
        }

        public async void OnSubmitAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://delvalle-001-site2.btempurl.com/Home/GetBalance?username=" + Application.Current.Properties["Username"] + "");
            viewModel.Balance = "Account Balance: " + JsonConvert.DeserializeObject<string>(response);
        }



        

        private void OnCashIn(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CashIn());
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            btnRefresh.IsEnabled = false;
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://delvalle-001-site2.btempurl.com/Home/GetBalance?username=" + Application.Current.Properties["Username"] + "");
            viewModel.Balance = "Account Balance: " + JsonConvert.DeserializeObject<string>(response);
            btnRefresh.IsEnabled = true;
        }

        private void Email_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ScanNow(viewModel.Balance));
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AboutUs());
        }

        private void Button_Clicked_2(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Schedule());
        }
    }
}