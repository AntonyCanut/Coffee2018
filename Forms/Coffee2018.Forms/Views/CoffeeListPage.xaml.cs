using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Coffee2018.Forms.Views
{
    public partial class CoffeeListPage
    {
        public CoffeeListPage()
        {
            InitializeComponent();
            ViewModel.StartAsync();
        }
    }
}
