using ViewModels;

namespace Views;

public partial class ExchangePage : ContentPage
{
    public ExchangePage() : this(new ExchangeViewModel())
    {
    }

    // קבלת ה-ViewModel ישירות דרך Dependency Injection וחיבור ה-Binding Context
    public ExchangePage(ExchangeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}