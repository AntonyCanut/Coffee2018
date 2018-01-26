using System;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace Coffee2018.Forms.Views
{
    public class ViewBase<T> : ContentPage
    {
        protected T ViewModel { get; set; }

        public ViewBase()
        {
            ViewModel = ServiceLocator.Current.GetInstance<T>();
            BindingContext = ViewModel;
        }
    }
}
