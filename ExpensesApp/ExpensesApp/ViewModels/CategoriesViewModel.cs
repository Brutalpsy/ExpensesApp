using ExpensesApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Internals;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel
    {
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> CategoryExpenses { get; set; }
        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpenses = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensesPerCategory();
        }

        private void GetExpensesPerCategory()
        {
            var totalAmmount = Expense.GetTotalExpensesAmmount();

            Categories.ForEach(category => {

                var categoryExpense = Expense.GetExpenses(category);
                var ammoutPerCategory = categoryExpense.Sum(expense => expense.Ammount);
                var percentage = ammoutPerCategory / totalAmmount ;
                CategoryExpenses.Add(new CategoryExpenses()
                {
                    Category = category,
                    ExpensesPercentage = percentage
                });
            });
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Travel");
            Categories.Add("Other");
            Categories.Add("");
        }
    }
}
