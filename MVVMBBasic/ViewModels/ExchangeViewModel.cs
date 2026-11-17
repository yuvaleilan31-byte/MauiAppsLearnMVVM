using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Windows.Input;
using System.Xml;

namespace ViewModels
{
    public class ExchangeViewModel:BaseViewModel
    {
        public ICommand ExchangeCommand { get; }

        private string _number = "0";
        private static Dictionary<string, double> ExchangeRateDict = new Dictionary<string, double> { { "Euro_Sheckel", 3.57 }, { "Dolar_Euro", 0.91 }, { "Euro_Lisht",0.83 }, { "Dolar_Sheckel", 3.25 }, { "Dolar_Lisht", 0.76 }, { "Lisht_Sheckel", 4.28} };
        private  static List<string> _options;

        private string _firstSelectedOption;
        private string _secondSelectedOption;

        private string _result="-";
        private string Title;

        public ExchangeViewModel() : base()
        {
            ExchangeCommand = new Command(Exchange);
            Title = "Exchange";
            CreateOptionList();
            _firstSelectedOption = ExchangeViewModel._options[0];
            _secondSelectedOption = ExchangeViewModel._options[1];
        }


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

        public String FirstSelectedOption
        {
            get => _firstSelectedOption;
            set
            {
                if (value != _firstSelectedOption)
                {
                    _firstSelectedOption = value;
                    OnPropertyChanged();
                }
            }
        }
        public String SecondSelectedOption
        {
            get => _secondSelectedOption;
            set
            {
                if (value != _secondSelectedOption)
                {
                    _secondSelectedOption = value;
                    OnPropertyChanged();
                }
            }
        }

        public String Number
        {
            get => _number;
            set
            {
                if (value != _number && int.TryParse(value, out int i))
                {
                    _number = value;
                    OnPropertyChanged();
                }
            }
        }
        
        


        
        public void Exchange()
        {
            if (int.TryParse(_number, out int num)) {
                if (_firstSelectedOption.Equals(_secondSelectedOption)){
                    Result = num.ToString();
                    return;
                }
                List<string> originalSeq = new List<string> {_firstSelectedOption ,_secondSelectedOption};
                originalSeq.Sort();
                string key = originalSeq[0] + "_" + originalSeq[1];

                if (originalSeq[0] ==  _firstSelectedOption)
                    Result = (num * ExchangeViewModel.ExchangeRateDict[key]).ToString();
                else
                    Result = (num / ExchangeViewModel.ExchangeRateDict[key]).ToString();

            }
        }
        private void CreateOptionList()
        {
            List<string> speacialCurrencies = new List<string>(), entriesInExchangeRateDict = new List<string>(ExchangeViewModel.ExchangeRateDict.Keys);
            foreach (string key in entriesInExchangeRateDict)
            {
                string[] currencies = key.Split('_');
                if (!speacialCurrencies.Contains(currencies[0]))
                    speacialCurrencies.Add(currencies[0]);
                if (!speacialCurrencies.Contains(currencies[1]))
                    speacialCurrencies.Add(currencies[1]);
            }
            _options = speacialCurrencies;


        }


    }
}
