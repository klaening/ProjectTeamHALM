using System;
using ToDoMobile.Services;
using ToDoMobile.Utility;
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
            //APIServices.GetRequest(ApiPaths.FullOrderDetails);
            MainPage = new NavigationPage(new OrderPage());
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
