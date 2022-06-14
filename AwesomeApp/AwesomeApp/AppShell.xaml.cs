using Xamarin.Forms;
using AwesomeApp.Views;

namespace AwesomeApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StudentEntryPage), typeof(StudentEntryPage));
        }
    }
}
