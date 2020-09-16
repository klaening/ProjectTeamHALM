using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ToDo_Desktop.ViewModels;
using ToDo_Desktop.Models;
using ToDo_Desktop.Services;
using System.Net;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDo_Desktop.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateOrder_InfoInput : Page
    {
        public readonly CreateOrder_InfoInput_VM _viewModel;
        public CreateOrder_InfoInput()
        {
            this.InitializeComponent();
            _viewModel = new CreateOrder_InfoInput_VM();
            DataContext = _viewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _viewModel.SelectedDepartment = (string)e.Parameter;
        }

        private void Return_Btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void Spara_btn_Click(object sender, RoutedEventArgs e)
        {
            WorkOrders workOrder = new WorkOrders
            {
                Description = ArbetsBeskrivning.Text,
                StartingDate = _viewModel.SelectedDate.UtcDateTime,
                StaffID = _viewModel.SelectedStaff.ID,
                OrderStatusesID = 1,
                CustomersID = _viewModel.SelectedCustomer.ID
            };

            try
            {
                var response = await Requests.PostRequestAsync(Paths.WorkOrders, workOrder);
                var statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var dialog = new MessageDialog("Work order successfully saved", "Success");
                    await dialog.ShowAsync();

                    //Fixa NavigationService?
                    var frame = (Frame)Window.Current.Content;
                    frame.GoBack();
                    //
                }
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong", "Error");
                await dialog.ShowAsync();
            }
        }
    }
}
