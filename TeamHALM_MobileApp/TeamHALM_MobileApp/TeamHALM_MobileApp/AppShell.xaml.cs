using System;
using System.Collections.Generic;
using System.Net.Http;
using TeamHALM_MobileApp.ViewModels;
using TeamHALM_MobileApp.Views;
using Xamarin.Forms;

namespace TeamHALM_MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            var client = new HttpClient();

            var response = client.GetAsync("https://webapihalm.azurewebsites.net/api/staff");
            var statusCode = response.Result;

            string result = statusCode.Content.ReadAsStringAsync().Result;     

            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
