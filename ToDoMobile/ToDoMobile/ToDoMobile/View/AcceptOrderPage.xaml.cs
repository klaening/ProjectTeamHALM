using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDoMobile.Model;
using ToDoMobile.Services;
using ToDoMobile.Utility;
using ToDoMobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Azure.NotificationHubs;


namespace ToDoMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcceptOrderPage : ContentPage
    {
        AcceptOrderPageVM _viewModel;


        public AcceptOrderPage(FullOrderDetails order)
        {
            InitializeComponent();
            _viewModel = new AcceptOrderPageVM();

            BindingContext = _viewModel;
            _viewModel.SelectedOrder = order;
            _viewModel.Navigation = Navigation;

            if (AcceptOrderButton.Text == "Accept")
            {
                DeclineOrderButton.IsVisible = true;
                UndoAcceptedOrderButton.IsVisible = false;
            }
            else
            {
                DeclineOrderButton.IsVisible = false;
                UndoAcceptedOrderButton.IsVisible = true;

            }
        }

  

        private void AcceptOrderButton_Clicked(object sender, EventArgs e)
        {
            if (AcceptOrderButton.Text == "Done")
            {
                OrderInfoStackLayout.IsVisible = false;
                RegisterAdditionalInformation.IsVisible = true;
            }
            else
            {
                OrderInfoStackLayout.IsVisible = true;
                RegisterAdditionalInformation.IsVisible = false;
            }
            SendTemplateNotificationAsync();
        }

        private void DeclineOrderButton_Clicked(object sender, EventArgs e)
        {

        }

        private void UndoAcceptedOrderButton_Clicked(object sender, EventArgs e)
        {

        }

        private void CompleteOrderButton_Clicked(object sender, EventArgs e)
        {

        }

        private static async void SendTemplateNotificationAsync()
        {
            // Define the notification hub.
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://teamhalmtestnotification.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=vj6kMiukDeWJm7DcY+t6GWAoVJI800JecK7pqiaOGeY=", "TeamHalmTestNotification");


            var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">Order has been changed to</text></binding></visual></toast>";
            await hub.SendWindowsNativeNotificationAsync(toast);
        }

    }
}