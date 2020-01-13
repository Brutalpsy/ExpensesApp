using ExpensesApp.Models;
using ExpensesApp.ViewModels;
using ExpensesApp.Views;
using Xamarin.Forms;

namespace ExpensesApp.Behavior
{
    public class ListViewBehavior : Behavior<ListView>
    {
        private ListView _listView;

        protected override void OnAttachedTo(ListView bindable)
        {

            base.OnAttachedTo(bindable);
            bindable.ItemSelected += Bindable_ItemSelected;
            _listView = bindable;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedExpense =_listView.SelectedItem as Expense;

            Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailView(selectedExpense));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= Bindable_ItemSelected;
        }

    }
}
