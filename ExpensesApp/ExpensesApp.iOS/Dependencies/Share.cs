using ExpensesApp.Interfaces;
using ExpensesApp.iOS.Dependencies;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.iOS.Dependencies
{
    public class Share : IShare
    {
        public async Task Show(string title, string message, string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}