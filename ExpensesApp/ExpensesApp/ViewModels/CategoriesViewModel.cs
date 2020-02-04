using ExpensesApp.Interfaces;
using ExpensesApp.Models;
using PCLStorage;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Resource = ExpensesApp.Resources.Resources;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel
    {
        public ICommand ExportCommand { get; set; }


        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> CategoryExpenses { get; set; }


        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpenses = new ObservableCollection<CategoryExpenses>();
            ExportCommand = new Command(async () => await ShareReport());

            GetCategories();
            GetExpensesPerCategory();
        }

        public void GetExpensesPerCategory()
        {
            var totalAmmount = Expense.GetTotalExpensesAmmount();
            CategoryExpenses.Clear();
            Categories.ForEach(category =>
            {

                var categoryExpense = Expense.GetExpenses(category);
                var ammoutPerCategory = categoryExpense.Sum(expense => expense.Ammount);
                var percentage = totalAmmount != 0 ? ammoutPerCategory / totalAmmount : 0;
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
            Categories.Add(Resource.Housing);
            Categories.Add(Resource.Debt);
            Categories.Add(Resource.Health);
            Categories.Add(Resource.Food);
            Categories.Add(Resource.Travel);
            Categories.Add(Resource.Personal);
            Categories.Add(Resource.Other);
        }

        public async Task ShareReport()
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

            var textFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

            using (StreamWriter sw = new StreamWriter(textFile.Path))
            {
                CategoryExpenses.ForEach(expense =>
                {
                    sw.WriteLine($"{expense.Category} - { expense.ExpensesPercentage:P}");
                });
            }

            var shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Expense report", "Here is your expenses report", textFile.Path);
        }
    }
}
