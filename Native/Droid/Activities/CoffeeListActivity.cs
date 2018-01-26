
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Coffee2018.Droid.Adapter;
using Coffee2018.ViewModels;

namespace Coffee2018.Droid.Activities
{
    [Activity(Label = "CoffeeListActivity")]
    public class CoffeeListActivity : ActivityBase<CoffeeListViewModel>
    {
        private ListView _listView;

        protected override int Layout => Resource.Layout.CoffeeList;

        protected override void SetupControls()
        {
            _listView = FindViewById<ListView>(Resource.Id.listCoffee);
            base.SetupControls();
        }

        protected override void InitializeViewModel()
        {
            base.InitializeViewModel();
            ViewModel.StartAsync();
        }

        protected override void OnViewModelPropertyChanged(string propertyName)
        {
            base.OnViewModelPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(ViewModel.ListCoffee):
                    FeedCoffeeList();
                    break;
            }
        }

        private void FeedCoffeeList()
        {
            var adapteur = new CoffeeListAdapteur(this, ViewModel.ListCoffee.ToArray());
            _listView.Adapter = adapteur;
        }
    }
}
