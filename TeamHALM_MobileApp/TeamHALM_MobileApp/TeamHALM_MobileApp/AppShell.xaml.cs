using System;
using System.Collections.Generic;
using TeamHALM_MobileApp.ViewModels;
using TeamHALM_MobileApp.Views;
using Xamarin.Forms;

namespace TeamHALM_MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
