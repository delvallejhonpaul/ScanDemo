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
    public partial class ScanNow : ContentPage
    {
        public bool IsScaned = false;
        public string balance = "0";
        public ScanNow(string _balance)
        {
            InitializeComponent();
            balance = _balance;
        }

        public void scanView_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //await DisplayAlert("Scanned result", "The barcode's text is " + result.Text + ". The barcode's format is " + result.BarcodeFormat, "OK");
                if (IsScaned == false)
                {
                    try
                    {
                        Item item = JsonConvert.DeserializeObject<Item>(result.Text);
                        item.Balance = balance.ToString();
                        if (!string.IsNullOrEmpty(item.Text) || !string.IsNullOrEmpty(item.Balance) || !string.IsNullOrEmpty(item.Price))
                        {
                            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item), balance));
                            IsScaned = true;
                        }
                    }
                    catch (System.Exception)
                    {

                    }


                }


            });
        }
    }
}