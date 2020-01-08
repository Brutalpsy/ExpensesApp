using ExpensesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesView : ContentPage
    {
        private readonly ExpensesViewModel _expensesViewModel;
        public ExpensesView()
        {
            InitializeComponent();
            _expensesViewModel = BindingContext as ExpensesViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _expensesViewModel.GetExpenses();
        }
    }
}