using ExpensesApp.Models;
using ExpensesApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel
    {
        public ICommand AddExpenseCommand { get; set; }
        public ObservableCollection<Expense> Expenses { get; set; }

        public ExpensesViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);
            GetExpenses();
        }

        private void GetExpenses()
        {
            var expenses = Expense.GetExpenses();
            Expenses.Clear();
            expenses.ForEach(expense => Expenses.Add(expense));
        }

        public void AddExpense()
        {
             Application.Current.MainPage.Navigation.PushAsync(new NewExpensesView());
        }
    }
}
