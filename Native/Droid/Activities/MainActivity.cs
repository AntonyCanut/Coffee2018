using Android.App;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Ioc;
using Coffee2018.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Coffee2018.ViewServices;
using Coffee2018.Droid.ViewServices;
using System.Collections.Generic;
using Coffee2018.Droid.Adapter;
using System.Linq;
using Android.Content;
using Java.Lang;
using Coffee2018.Commands;

namespace Coffee2018.Droid.Activities
{
    [Activity(Label = "Coffee2018", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ActivityBase<MainViewModel>
    {
        private Button _buttonNext;

        protected override int Layout => Resource.Layout.Main;

        protected override void SetupControls()
        {
            _buttonNext = FindViewById<Button>(Resource.Id.NextButton);
        }

        protected override void UnsubscribeFromViewEvents()
        {
            _buttonNext.Click -= Button_Click;
            base.UnsubscribeFromViewEvents();
        }

        protected override void SubscribeToViewEvents()
        {
            base.SubscribeToViewEvents();
            _buttonNext.Click += Button_Click;
        }

        protected override void InitializeViewModel()
        {
            base.InitializeViewModel();
            ViewModel.NavigateToCoffeeReverseCommand = new ReverseCommand(NavigateToCoffeeList);
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            //var context = this.BaseContext.con;
            ViewModel.CoffeeCommand.Execute(null);
        }

        private void NavigateToCoffeeList()
        {
            Intent intent = new Intent(this, typeof(CoffeeListActivity));
            StartActivity(intent);
        }
    }
}

