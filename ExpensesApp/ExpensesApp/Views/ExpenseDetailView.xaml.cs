using ExpensesApp.Models;
using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailView : ContentPage
    {
        private readonly ExpenseDetailViewModel _expenseDetailViewModel;
        public ExpenseDetailView()
        {
            InitializeComponent();
        }

        public ExpenseDetailView(Expense expense)
        {
            InitializeComponent();
            _expenseDetailViewModel = BindingContext as ExpenseDetailViewModel;
            _expenseDetailViewModel.Expense = expense;
            BindingContext = _expenseDetailViewModel;
        }
    }
}