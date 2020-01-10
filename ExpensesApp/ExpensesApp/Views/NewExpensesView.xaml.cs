using ExpensesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensesView : ContentPage
    {
        private readonly NewExpensesViewModel _newExpensesViewModel;
        public NewExpensesView()
        {
            InitializeComponent();
            _newExpensesViewModel = BindingContext as NewExpensesViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _newExpensesViewModel.GetExpenseStatuses();

            var statuses = _newExpensesViewModel.ExpendStatuses;
            var section = new TableSection("Statuses");
            for (int i = 0; i < statuses.Count; i++)
            {
                var cell = new SwitchCell() { Text = statuses[i].Name };

                Binding binding = new Binding()
                {
                    Source = statuses[i],
                    Path = "Status",
                    Mode = BindingMode.TwoWay,
                };

                cell.SetBinding(SwitchCell.OnProperty, binding);
                section.Add(cell);
            }
            expenseTableView.Root.Add(section);

        }
    }
}