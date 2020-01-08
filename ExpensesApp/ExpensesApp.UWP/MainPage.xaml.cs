using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ExpensesApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string db_name = "db.db";
            string folder_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            string full_path = Path.Combine(folder_path, db_name);


            LoadApplication(new ExpensesApp.App(full_path));
        }
    }
}
