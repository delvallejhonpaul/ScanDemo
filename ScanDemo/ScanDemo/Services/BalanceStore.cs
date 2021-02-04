using System;
using System.Collections.Generic;
using System.Text;

namespace ScanDemo.Services
{

    public class BalanceStore
    {
        private string password = "0";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
    }
}
