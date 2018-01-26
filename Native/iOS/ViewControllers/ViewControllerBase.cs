using System;
using System.ComponentModel;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace Coffee2018.iOS.ViewControllers
{
    public abstract class ViewControllerBase<T> : UIViewController
        where T : INotifyPropertyChanged
    {
        protected T ViewModel { get; set; }

        public ViewControllerBase(IntPtr handle) : base(handle)
        {
            ViewModel = ServiceLocator.Current.GetInstance<T>();
        }

        protected virtual void SubscribeToViewEvents()
        {
            UnsubscribeFromViewEvents();
        }

        protected virtual void UnsubscribeFromViewEvents()
        {

        }

        protected virtual void SubscribeToViewModelEvents()
        {
            UnsubscribeFromViewModelEvents();

            ViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        protected virtual void UnsubscribeFromViewModelEvents()
        {
            ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            SubscribeToViewEvents();
            SubscribeToViewModelEvents();
        }

        public override void ViewWillDisappear(bool animated)
        {
            UnsubscribeFromViewEvents();
            UnsubscribeFromViewModelEvents();

            base.ViewWillDisappear(animated);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupControls();
            SubscribeToViewEvents();
            SubscribeToViewModelEvents();
            InitializeViewModel();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            UnsubscribeFromViewEvents();
            UnsubscribeFromViewModelEvents();
        }

        protected virtual void OnViewModelPropertyChanged(string propertyName)
        {

        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnViewModelPropertyChanged(e.PropertyName);
        }

        protected virtual void SetupControls()
        {

        }

        protected virtual void InitializeViewModel()
        {

        }
    }
}
