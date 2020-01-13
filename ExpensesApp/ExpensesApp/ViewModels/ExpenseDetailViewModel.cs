using ExpensesApp.Models;
using ExpensesApp.ViewModels.Base;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailViewModel : ViewModelBase
    {
        private Expense _expense;
        public Expense Expense 
        {
            get { return _expense; }
            set 
            {
                _expense = value;
                OnPropertyChanged();
            }
        }


        public ExpenseDetailViewModel()
        {
        }
    }
}
