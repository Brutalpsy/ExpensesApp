using ExpensesApp.Droid.Effects;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("myCo")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApp.Droid.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        Android.Graphics.Color selectedColor;

        protected override void OnAttached()
        {
            selectedColor = new Android.Graphics.Color(176, 152, 164);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "IsFocused")
            {
                if (Control.IsFocused)
                {
                    Control.SetBackgroundColor(selectedColor);
                }
                else
                {
                    Control.SetBackgroundColor(Android.Graphics.Color.White);
                }
            }

        }

        protected override void OnDetached()
        {
        }
    }
}