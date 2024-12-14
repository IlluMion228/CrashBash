using Microsoft.Maui.Controls;

namespace CrashBash
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); // Установка стартовой страницы
        }
    }
}
