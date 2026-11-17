using Microsoft.Maui.Controls;
using System;
using ViewModels;

namespace Views
{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage() : this(new CalculatorViewModel())
        {
        }

        // קבלת ה-ViewModel ישירות דרך Dependency Injection וחיבור ה-Binding Context
        public CalculatorPage(CalculatorViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }



    }
}



