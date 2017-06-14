using VoxPopuliApp.Menu;
using VoxPopuliApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VoxPopuliApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainMenu();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Campañas Activas",
                        Icon = Device.OnPlatform("tab_feed.png","tab_feed.png","tab_feed.png")
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "Acerca de",
                        Icon = Device.OnPlatform("tab_about.png","tab_about.png","tab_about.png")
                    },
                }
            };
        }
    }
}
