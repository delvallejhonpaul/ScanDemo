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
    public class ScanViewModel: BaseViewModel
    {
        public ICommand SubmitCommand { protected set; get; }
        public ScanViewModel()
        {
            Balance = "Loading...";
            Title = "Scan";
        }
       


    }
}
