﻿using System;
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
            
        
        }

  

        private void AcceptOrderButton_Clicked(object sender, EventArgs e)
        {
                AdditionalInformation.IsVisible = true;
            
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