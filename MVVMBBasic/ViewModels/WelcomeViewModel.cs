using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public ICommand NavigateToCalcAgeCommand { get; }

        public ICommand NavigateToCalculatorCommand { get; }

        public ICommand NavigateToExchangeCommand { get; }

        public string t = "gvnrfidj";
        public WelcomeViewModel()
        {


            NavigateToCalcAgeCommand = new Command(async () =>
            {
                //Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout; // 1. משחרר את החסימה
                await Shell.Current.GoToAsync("//CalcAge");          // 2. ניווט מוחלט (Absolute)
            });

            NavigateToCalculatorCommand = new Command(async () =>
            {
                //Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout; // 1. משחרר את החסימה
                await Shell.Current.GoToAsync("//CalculatorPage");          // 2. ניווט מוחלט (Absolute)
            });
            NavigateToExchangeCommand = new Command(async () =>
            {
                //Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout; // 1. משחרר את החסימה
                await Shell.Current.GoToAsync("//ExchangePage");          // 2. ניווט מוחלט (Absolute)
            });


            Title = "Welcome Page";
            this.t = "v73982";
        }

        private async void OnContactClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ContactPage");
        }

    }
}
