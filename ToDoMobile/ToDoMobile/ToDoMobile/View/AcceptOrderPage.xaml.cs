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

        

    }
}