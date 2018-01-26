using System;
using System.Threading.Tasks;
using Coffee2018.ViewServices;
namespace Coffee2018.Forms.ViewServices
{
    public class AlertService : IAlertService
    {
        public Task<bool> ShowAsync(string title, string message, string okButton, string cancelButton)
        {
            return Xamarin.Forms.Application.Current.MainPage.DisplayAlert(title, message, okButton, cancelButton);
        }
    }
}
