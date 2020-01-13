
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using System.IO;
using Xamarin.Forms;

namespace ExpensesApp.Droid
{
    [Activity(Label = "ExpensesApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            string db_name = "expenses_db.db3";
            string folder_path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            string full_path = Path.Combine(folder_path, db_name);

            //DependencyService.Register<IShare, Share>();
      


            LoadApplication(new App(full_path));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}