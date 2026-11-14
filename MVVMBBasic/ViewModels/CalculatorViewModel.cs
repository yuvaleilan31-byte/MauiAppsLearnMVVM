//using Android.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace MVVMBBasic.ViewModels
{
    internal class CalculatorViewModel:BaseViewModel
    {

        public ICommand AddCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }
        public ICommand SubtractCommand { get; }

        private string _result="";
        private string _num1="0";
        private string _num2="0";
        public CalculatorViewModel(){
            Title = "דף מחשבון";
            AddCommand = new Command(Add);
            MultiplyCommand = new Command(Multiply);
            DivideCommand = new Command(Divide);
            SubtractCommand = new Command(Subtract);
        }

        String Result
        {
            get => _result;
            set  {
                if (value != _result) {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }

        String Num1
        {
            get => _num1;
            set {
                if (value != _num1 && int.TryParse(value, out int i))
                {
                    _num1 = value;
                    OnPropertyChanged();
                }
            }
        }
        String Num2
        {
            get => _num2;
            set
            {
                if (value != _num2 && int.TryParse(value, out int i))
                {
                    _num2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public void Add()
        {
            if(int.TryParse(Num1, out int n1) && int.TryParse(Num2, out int n2)){
                Result = (n1 + n2).ToString();
            }
            else {
                Result = "Invalid input - the input must be an integer";
            }
        }
        public void Multiply()
        {
            if (int.TryParse(Num1, out int n1) && int.TryParse(Num2, out int n2)){
                Result = (n1 + n2).ToString();
            }
            else
            {
                Result = "Invalid input - the input must be an integer";
            }
        }
        public void Divide()
        {
            if (int.TryParse(Num1, out int n1) && int.TryParse(Num2, out int n2)){
                Result = (n1 + n2).ToString();
            }
            else
            {
                Result = "Invalid input - the input must be an integer";
            }
        }
        public void Subtract()
        {
            if (int.TryParse(Num1, out int n1) && int.TryParse(Num2, out int n2)){
                Result = (n1 + n2).ToString();
            }
            else
            {
                Result = "Invalid input - the input must be an integer";
            }
        }

    }
}
