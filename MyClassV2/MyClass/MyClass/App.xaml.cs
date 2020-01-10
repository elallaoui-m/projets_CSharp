using MyClass.Views;
using MyClass.TabbedPageExample;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyClass
{
    public partial class App : Application
    {
        public static string databasePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            
        }

        public App(string filePath)
        {
            InitializeComponent();

            MainPage = new LoginPage();

            databasePath = filePath;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
