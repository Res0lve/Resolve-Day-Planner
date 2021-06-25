using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ResolveDayPlanner.Services;
using ResolveDayPlanner.Views;
using System.IO;
using Xamarin.Essentials;

namespace ResolveDayPlanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Remove comments to register everytime the app starts
            // string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "login.txt");
            // File.Delete(filePath);
            DependencyService.Register<ErrandDataStore>();
            MainPage = new AppShell();
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
