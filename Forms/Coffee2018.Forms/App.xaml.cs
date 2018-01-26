using Xamarin.Forms;
using Coffee2018.Forms.Views;
using GalaSoft.MvvmLight.Ioc;
using Coffee2018.ViewServices;
using Coffee2018.Services;
using Coffee2018.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Coffee2018.Forms.ViewServices;

namespace Coffee2018.Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var container = SimpleIoc.Default;
            container.Register<IAlertService, AlertService>();
            container.Register<ICoffeeService, CoffeeService>();
            container.Register<MainViewModel>();
            container.Register<CoffeeListViewModel>();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
