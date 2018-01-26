using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Coffee2018.ViewServices;

namespace Coffee2018.Droid.ViewServices
{
    public class AlertService : IAlertService
    {
        public Context Context { get; set; }

        public Task<bool> ShowAsync(string title, string message, string ok, string cancel)
        {
            if (Context == null)
            {
                return Task.FromResult(false);
            }

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            var builder = new AlertDialog.Builder(Context)
                                         .SetTitle(title)
                                         .SetMessage(message)
                                         .SetPositiveButton(ok, (sender, e) => tcs.TrySetResult(true))
                                         .SetNegativeButton(cancel, (sender, e) => tcs.TrySetResult(false));
            var dialog = builder.Create();
            dialog.Show();

            return tcs.Task;
        }
    }
}
