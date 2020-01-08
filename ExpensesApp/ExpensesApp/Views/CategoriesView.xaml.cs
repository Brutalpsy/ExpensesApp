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
    public partial class CategoriesView : ContentPage
    {
        private readonly CategoriesViewModel _categoriesViewModel;
        public CategoriesView()
        {
            InitializeComponent();
            _categoriesViewModel = BindingContext as CategoriesViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _categoriesViewModel.GetExpensesPerCategory();
        }
    }
}