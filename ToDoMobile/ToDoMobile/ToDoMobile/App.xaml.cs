using System;
using ToDoMobile.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OrderPagePending());
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
