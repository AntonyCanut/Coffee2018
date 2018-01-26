using System;
using System.Threading.Tasks;
using Coffee2018.ViewServices;
using UIKit;

namespace Coffee2018.iOS.ViewServices
{
    public class AlertService : IAlertService
    {
        public Task<bool> ShowAsync(string title, string message, string ok, string cancel)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            UIApplication.SharedApplication.BeginInvokeOnMainThread(() =>
            {
                var uc = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
                uc.AddAction(UIAlertAction.Create(ok, UIAlertActionStyle.Default, _ => tcs.TrySetResult(true)));
                uc.AddAction(UIAlertAction.Create(cancel, UIAlertActionStyle.Default, _ => tcs.TrySetResult(false)));

                var nav = (UINavigationController)UIApplication.SharedApplication.KeyWindow.RootViewController;
                nav.PresentViewController(uc, true, null);
            });

            return tcs.Task;
        }
    }
}
