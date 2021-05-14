using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SBEarthquakeSearchApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Pass in main page as the navigation page
            MainPage = new NavigationPage(new MainPage());
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
