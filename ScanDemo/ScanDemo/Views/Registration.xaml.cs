using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScanDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public Registration()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                if (IsValidEmail(txtEmail.Text))
                {
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        if (!string.IsNullOrEmpty(txtPassword.Text))
                        {
                            if (txtPassword.Text == txtConfirmPassword.Text)
                            {
                                var httpClient = new HttpClient();
                                var response = await httpClient.GetStringAsync("http://delvalle-001-site2.btempurl.com/Home/Registration?username=" + txtEmail.Text + "&password=" + txtPassword.Text + "");
                                var status = JsonConvert.DeserializeObject<string>(response);
                                if (status == "true")
                                {
                                    DisplayAlert("Success", "Successfully Registered.", "Close");
                                }
                                else
                                {
                                    DisplayAlert("Error", "Already Registered.", "Close");
                                }
                            }
                            else
                            {
                                DisplayAlert("Error", "Password is not match.", "Close");
                            }
                        }
                        else
                        {
                            DisplayAlert("Error", "Please confrm your password.", "Close");
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "Password is required.", "Close");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Not a valid email.", "Close");
                }
               
            }
            else
            {
                DisplayAlert("Error", "Email is required.", "Close");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}