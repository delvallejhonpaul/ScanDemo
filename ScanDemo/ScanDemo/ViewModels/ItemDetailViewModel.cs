﻿using System;

using ScanDemo.Models;

namespace ScanDemo.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
            Price = item.Price;
        }
    }
}
