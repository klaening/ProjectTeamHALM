using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashLoginPage : ContentPage
    {
        public SplashLoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void LogInButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderPage());
        }
    }
}