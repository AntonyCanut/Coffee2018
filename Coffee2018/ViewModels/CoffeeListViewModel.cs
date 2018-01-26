using System;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using Coffee2018.Services;
using System.Threading.Tasks;
using System.Threading;
using Coffee2018.Models;

namespace Coffee2018.ViewModels
{
    public class CoffeeListViewModel : ViewModelBase
    {
        private readonly ICoffeeService _coffeeService;

        private List<Record> _listCoffee;
        public List<Record> ListCoffee
        {
            get { return _listCoffee; }
            set { Set(ref _listCoffee, value); }
        }

        public CoffeeListViewModel(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        public async Task StartAsync()
        {
            ListCoffee = await _coffeeService.GetCoffeeListAsync(CancellationToken.None);
        }
    }
}
