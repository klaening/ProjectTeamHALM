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
    public partial class OrderInformationPage : ContentPage
    {
        public OrderInformationPage()
        {
            InitializeComponent();
        }


        
        private async void AcceptButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new OrderPage())); 
            //PopUp Confirmation
            //Ändra status från pending till accepted 
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            AdditionalInformation.IsVisible = true;
        }

        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new OrderPage()));
            //PopUp Confirmation
            //Ändra status från accepted till review
            
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderPage());
        }
    }
}