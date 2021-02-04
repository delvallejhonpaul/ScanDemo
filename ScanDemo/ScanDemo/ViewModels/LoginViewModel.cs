using ScanDemo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScanDemo.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmitAsync);
        }
        public async void OnSubmitAsync(object obj)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://delvalle-001-site2.btempurl.com/Home/Login?username=" + email + "&password=" + password + "");
            var login = response;
            Debug.WriteLine(login);
            if (login != "\"\"")
            {
                Application.Current.Properties["Username"] = email;
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}
