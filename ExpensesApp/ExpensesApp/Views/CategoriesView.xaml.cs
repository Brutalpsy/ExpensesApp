using ExpensesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesView : ContentPage
    {
        private readonly CategoriesViewModel _categoriesViewModel;
        public CategoriesView()
        {
            InitializeComponent();
            _categoriesViewModel = BindingContext as CategoriesViewModel;

            SizeChanged += CategoriesView_SizeChanged;
        }

        private void CategoriesView_SizeChanged(object sender, System.EventArgs e)
        {
            var visualState = Width > Height ? "Landscape" : "Portrait";
            VisualStateManager.GoToState(titleLabel, visualState);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _categoriesViewModel.GetExpensesPerCategory();
        }
    }
}