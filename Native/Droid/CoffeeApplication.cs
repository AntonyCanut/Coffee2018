using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Coffee2018.Droid.ViewServices;
using Coffee2018.ViewModels;
using Coffee2018.ViewServices;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Coffee2018.Services;

namespace Coffee2018.Droid
{
    [Application]
    public class CoffeeApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public CoffeeApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }

        public override void OnCreate()
        {
            var container = SimpleIoc.Default;
            container.Register<IAlertService, AlertService>();
            container.Register<ICoffeeService, CoffeeService>();
            container.Register<MainViewModel>();
            container.Register<CoffeeListViewModel>();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterActivityLifecycleCallbacks(this);

            base.OnCreate();
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            ((AlertService)SimpleIoc.Default.GetInstance<IAlertService>()).Context = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
            //throw new NotImplementedException();
        }

        public void OnActivityPaused(Activity activity)
        {
            //throw new NotImplementedException();
        }

        public void OnActivityResumed(Activity activity)
        {
            ((AlertService)SimpleIoc.Default.GetInstance<IAlertService>()).Context = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
            //throw new NotImplementedException();
        }

        public void OnActivityStarted(Activity activity)
        {
            ((AlertService)SimpleIoc.Default.GetInstance<IAlertService>()).Context = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
            //throw new NotImplementedException();
        }
    }
}
