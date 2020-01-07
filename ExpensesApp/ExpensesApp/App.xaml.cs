using ExpensesApp.Views;
using Xamarin.Forms;

namespace ExpensesApp
{
    public partial class App : Application
    {
        public static string DatabasePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
        }
        public App(string databasePath)
        {
            InitializeComponent();
            DatabasePath = databasePath;
            MainPage = new NavigationPage(new MainView());
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
