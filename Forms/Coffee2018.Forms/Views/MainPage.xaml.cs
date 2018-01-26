using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Coffee2018.Commands;

namespace Coffee2018.Forms.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            ViewModel.NavigateToCoffeeReverseCommand = new ReverseCommand(NavigateToCoffee);
        }

        private void NavigateToCoffee()
        {
            Navigation.PushAsync(new CoffeeListPage());
        }
    }
}
