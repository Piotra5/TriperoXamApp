using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tripero.Services;
using Tripero.Views;

namespace Tripero
{
    public partial class App : Application
    {
        public static double ScreenHeight;
        public static double ScreenWidth;
        public static readonly string GOOGLE_MAP_API_KEY = "AIzaSyD6mlhMXnClcDGte0o2gnqNl_8EloHpxQk";
        public App()
        {
            InitializeComponent();

            DependencyService.Register<TripDataStore>();
            MainPage = new MainPage();
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
