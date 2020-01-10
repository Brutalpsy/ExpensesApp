using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using ExpensesApp.Droid.CustomRenderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace ExpensesApp.Droid.CustomRenderers
{
    public class CustomTextCellRenderer : TextCellRenderer
    {
        public CustomTextCellRenderer()
        {
        }

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);
            var bmp = BitmapFactory.DecodeResource(cell.Resources, Resource.Drawable.info);
            var bitmapDrawable = new BitmapDrawable(cell.Resources, Bitmap.CreateScaledBitmap(bmp, 50, 50, true));
            bitmapDrawable.Gravity = GravityFlags.Right | GravityFlags.CenterVertical;

            switch (item.StyleId)
            {
                case "icon":
                    cell.SetBackground(bitmapDrawable);
                    break;
                default:
                    break;
            }
            return cell;
        }
    }
}