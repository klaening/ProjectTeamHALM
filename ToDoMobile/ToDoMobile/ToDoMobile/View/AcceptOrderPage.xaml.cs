﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMobile.Model;
using ToDoMobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcceptOrderPage : ContentPage
    {
        AcceptOrderPageVM _viewModel;
        public AcceptOrderPage(WorkOrders order)
        {
            InitializeComponent();
            _viewModel = new AcceptOrderPageVM();

            BindingContext = _viewModel;
            _viewModel.SelectedOrder = order;
            _viewModel.Navigation = Navigation;
        }

    }
}