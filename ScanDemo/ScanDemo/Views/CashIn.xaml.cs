using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CashIn : ContentPage
    {
        public CashIn()
        {
            InitializeComponent();

            

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var price = Convert.ToInt32(txtPrice.Text);

                if (price >= 500 && price <= 5000)
                {
                    Browser.OpenAsync("http://delvalle-001-site2.btempurl.com/home/ProceedNew?username=" + Application.Current.Properties["Username"] + "&price=" + txtPrice.Text);
                }
                else
                {
                    DisplayAlert("Error", "Minimum of 500 and maximum of 5000", "Close");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Error", "Invalid value", "Close");
            }

            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}