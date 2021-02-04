using ScanDemo.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScanDemo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(OnSubmitAsync);
        }

        public ICommand OpenWebCommand { get; }

        public async void OnSubmitAsync(object obj)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}