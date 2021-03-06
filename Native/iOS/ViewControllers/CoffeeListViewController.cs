// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;
using Coffee2018.iOS.ViewControllers;
using Coffee2018.ViewModels;
using Coffee2018.iOS.ViewSources;
using Coffee2018.iOS.ViewCells;

namespace Coffee2018.iOS
{
    public partial class CoffeeListViewController : ViewControllerBase<CoffeeListViewModel>
    {
        public CoffeeListViewController(IntPtr handle) : base(handle)
        {
        }

        protected override void SetupControls()
        {
            NavigationController.NavigationBar.Hidden = false;

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
            UITableViewSource viewSource = new CoffeViewSource(ViewModel.ListCoffee.ToArray());
            CoffeeTableView.Source = viewSource;
            CoffeeTableView.RegisterNibForCellReuse(CoffeeViewCell.Nib, "TableCell");
            CoffeeTableView.ReloadData();
        }
    }
}
