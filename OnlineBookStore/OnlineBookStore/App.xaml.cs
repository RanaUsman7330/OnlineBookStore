using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineBookStore
{
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Universe.db3");

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new FirstPage());
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
