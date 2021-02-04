using System;
using System.Collections.Generic;
using System.Text;

namespace ScanDemo.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}
