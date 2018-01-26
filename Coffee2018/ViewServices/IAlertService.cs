using System;
using System.Threading.Tasks;
namespace Coffee2018.ViewServices
{
    public interface IAlertService
    {
        Task<bool> ShowAsync(string title, string message, string okButton, string cancelButton);
    }
}
