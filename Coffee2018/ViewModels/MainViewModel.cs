using System;
using GalaSoft.MvvmLight;
using Coffee2018.ViewServices;
using System.Threading.Tasks;
using Coffee2018.Commands;
using System.Windows.Input;

namespace Coffee2018.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAlertService _alertService;

        public ICommand CoffeeCommand { get; set; }
        public ICommand NavigateToCoffeeReverseCommand { get; set; }

        public MainViewModel(IAlertService alertService)
        {
            _alertService = alertService;

            CoffeeCommand = new SyncCommand(SeeCoffee);
        }

        private void SeeCoffee()
        {
            SeeCoffeeAsync();
        }

        private async Task SeeCoffeeAsync()
        {
            try
            {
                //throw new Exception("Les Poules Ont Des Dents !");
                var response = await _alertService.ShowAsync("Bonjour", "Voulez-vous voir les cafés", "Ok", "Annuler");
                if (response)
                    NavigateToCoffeeReverseCommand.Execute(null);
            }
            catch (Exception e)
            {
                await _alertService.ShowAsync("Error", e.Message, "Ok", "Annuler");
            }
        }


    }
}
