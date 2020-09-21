using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ToDo_Desktop.ExtensionMethods;
using ToDo_Desktop.Models;
using ToDo_Desktop.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDo_Desktop.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditOrderPage : Page
    {
        private readonly EditOrderPage_VM _viewModel;
        public EditOrderPage()
        {
            this.InitializeComponent();
            _viewModel = new EditOrderPage_VM();
            DataContext = _viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _viewModel.SelectedOrder = (OrderInfo)e.Parameter;
            //_viewModel.OriginalOrder = CopyOrder(_viewModel.SelectedOrder);
            _viewModel.SelectedCustomer = _viewModel.CustomerList.FirstOrDefault(x => x.ID == _viewModel.SelectedOrder.CustomersID);
            _viewModel.SelectedStaff = _viewModel.StaffList.FirstOrDefault(x => x.ID == _viewModel.SelectedOrder.StaffID);
            _viewModel.SelectedStatus = _viewModel.StatusList.FirstOrDefault(x => x.ID == _viewModel.SelectedOrder.OrderStatusesID);
            _viewModel.SelectedDate = _viewModel.SelectedOrder.StartingDate;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        //private OrderInfo CopyOrder(OrderInfo orderInfo)
        //{
        //    return _viewModel.OriginalOrder = new OrderInfo
        //    {
        //        ID = orderInfo.ID,
        //        OrderDescription = orderInfo.OrderDescription,
        //        StartingDate = orderInfo.StartingDate,
        //        Commentary = orderInfo.Commentary,
        //        HoursSpent = orderInfo.HoursSpent,
        //        TravelTime = orderInfo.TravelTime,
        //        ExtraCosts = orderInfo.ExtraCosts,
        //        StaffID = orderInfo.StaffID,
        //        StaffName = orderInfo.StaffName,
        //        DepartmentsID = orderInfo.DepartmentsID,
        //        DepartmentName = orderInfo.DepartmentName,
        //        OrderStatusesID = orderInfo.OrderStatusesID,
        //        StatusName = orderInfo.StatusName,
        //        CustomersID = orderInfo.CustomersID,
        //        CustomerName = orderInfo.CustomerName,
        //        CustomerAddress = orderInfo.CustomerAddress,
        //        CustomerPhoneNo = orderInfo.CustomerPhoneNo
        //    };
        //}
    }
}
