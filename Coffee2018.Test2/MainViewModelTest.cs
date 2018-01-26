using System;
using Coffee2018.ViewModels;
using NUnit.Framework;
using NSubstitute;
using Coffee2018.ViewServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Coffee2018.Commands;

namespace Coffee2018.Tests
{
    [TestFixture]
    public class MainViewModelTest
    {
        private MainViewModel _viewModel;

        private IAlertService _alertService;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _alertService = Substitute.For<IAlertService>();
            _viewModel = new MainViewModel(_alertService)
            {
                NavigateToCoffeeReverseCommand = Substitute.For<ICommand>(null)
            };
        }

        [TearDown]
        public void TearDown()
        {
            _viewModel = null;
        }

        [Test]
        public void Must_Navigate_To_Coffee_When_Button_Clicked()
        {
            // Arrange
            // Act
            _viewModel.CoffeeCommand.Execute(null);

            // Assert
            _alertService.ReceivedWithAnyArgs(1).ShowAsync(null, null, null, null);
        }
    }
}
