using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModels
{
    internal class ExchangeViewModel:BaseViewModel
    {
        public ICommand ExchangeCommand {  get; }

        private static Dictionary<string, double> dict = new Dictionary<string, double> { { "Euro", 5 }, { "Dolar", 3.2 }, { "Yen",0.02 } };
        private  static List<string> _options = new List<string>(ExchangeViewModel.dict.Keys);

        private string _selectedOption= ExchangeViewModel._options[0];

        private string _result="-";
        private string Title;
        private string _sheckels="0";

        public String Result
        {
            get => _result;
            set
            {
                if (value != _result)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<String> Options
        {
            get => ExchangeViewModel._options;
            
        }

        public String Sheckels
        {
            get => _sheckels;
            set
            {
                if (value != _sheckels && int.TryParse(value, out int i))
                {
                    _sheckels = value;
                    OnPropertyChanged();
                }
            }
        }
        public String SelectedOption
        {
            get => _selectedOption;
            set
            {
                if (value != _selectedOption)
                {
                    _selectedOption = value;
                    OnPropertyChanged();
                }
            }
        }




        public ExchangeViewModel()
        {
            ExchangeCommand = new Command(Exchange); ;
            Title = "Exchange";

        }
        public void Exchange()
        {
            if (int.TryParse(_result, out int i)) {
                this.Result = (i / ExchangeViewModel.dict[this._selectedOption]).ToString();
                    
            }
        }

    }
}
