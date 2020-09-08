using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TeamHALM_MobileApp.Services;
using TeamHALM_MobileApp.Views;

namespace TeamHALM_MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
