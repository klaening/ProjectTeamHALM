using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo_Desktop.Models;
using ToDo_Desktop.Services;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace ToDo_Desktop.ViewModels
{
 
    public class AdminMainPage_VM : BindableBase
    {
        private Visibility isVisible = Visibility.Collapsed;
        

        private NavigationService navigationService;
        private ObservableCollection<OrderInfo> _orderInfo = new ObservableCollection<OrderInfo>();
        private OrderInfo _selectedOrderInfo;

        private ObservableCollection<OrderStatuses> _statusList;
        public ObservableCollection<OrderStatuses> StatusList
        {
            get => _statusList;
            set => SetProperty(ref _statusList, value);
        }

        public ObservableCollection<OrderInfo> OrderInfo
        {
            get => _orderInfo;
            set => SetProperty(ref _orderInfo, value);
        }

        public OrderInfo SelectedOrderInfo
        {
            get => _selectedOrderInfo;
            set 
            { 
                SetProperty(ref _selectedOrderInfo, value);
                if (value != null)
                {
                    IsVisible = Visibility.Visible;
                    OrderSelected = Visibility.Visible;
                }
                else
                {
                    OrderSelected = Visibility.Collapsed;
                }
            }
        }

        private Visibility _orderSelected = Visibility.Collapsed;
        public Visibility OrderSelected 
        {
            get => _orderSelected;
            set => SetProperty(ref _orderSelected, value);
        }

        public Visibility IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                if (SelectedOrderInfo.StatusName == "Review")
                    SetProperty(ref isVisible, Visibility.Visible);
                else
                    SetProperty(ref isVisible, Visibility.Collapsed);
            }
        }


        public AdminMainPage_VM()
        {
            navigationService = new NavigationService();

            UpdateOrderList();

            var result = Requests.GetRequest(Paths.OrderStatuses);
            StatusList = JsonConvert.DeserializeObject<ObservableCollection<OrderStatuses>>(result);

            DeleteCommand = new RelayCommand(DeleteWorkOrder, () => true);

            AcceptCommand = new RelayCommand(AcceptOrderAsync, () => true);
        }

        public ICommand DeleteCommand { get; set; }
        private async void DeleteWorkOrder()
        {
            var dialog = new MessageDialog("Are you sure you want to delete?", "Warning");
            dialog.Commands.Add(new UICommand("Yes", null));
            dialog.Commands.Add(new UICommand("Cancel", null));

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var command = await dialog.ShowAsync();

            if (command.Label == "Yes")
            {
                try
                {
                    var response = await Requests.DeleteRequestAsync(Paths.WorkOrders, SelectedOrderInfo.ID);
                    var statusCode = response.StatusCode;


                    if (statusCode == HttpStatusCode.OK)
                    {
                        dialog = new MessageDialog("Work order successfully deleted", "Success");
                        await dialog.ShowAsync();
                    }
                    UpdateOrderList();
                }
                catch (Exception)
                {
                    dialog = new MessageDialog("Something went wrong", "Error");
                    await dialog.ShowAsync();
                }
            }
        }

        public ICommand AcceptCommand { get; set; }

        private async void AcceptOrderAsync()
        {

            WorkOrders updatedOrder = new WorkOrders
            {
                ID = SelectedOrderInfo.ID,
                OrderDescription = SelectedOrderInfo.OrderDescription,
                StartingDate = SelectedOrderInfo.StartingDate,
                Commentary = SelectedOrderInfo.Commentary,
                HoursSpent = SelectedOrderInfo.HoursSpent,
                TravelTime = SelectedOrderInfo.TravelTime,
                ExtraCosts = SelectedOrderInfo.ExtraCosts,
                StaffID = SelectedOrderInfo.StaffID,
                OrderStatusesID = SelectedOrderInfo.OrderStatusesID + 1,
                CustomersID = SelectedOrderInfo.CustomersID,
                OrderTitle = SelectedOrderInfo.OrderTitle
            };

            try
            {
                var response = await Requests.PutRequestAsync(Paths.WorkOrders, updatedOrder);
                var statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var dialog = new MessageDialog("Work order successfully updated", "Success");
                    await dialog.ShowAsync();

                    UpdateOrderList();
                }
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong", "Error");
                await dialog.ShowAsync();
            }
        }

        private void UpdateOrderList()
        {
            var result = Requests.GetRequest(Paths.FullOrderDetails);
            OrderInfo = JsonConvert.DeserializeObject<ObservableCollection<OrderInfo>>(result);
        }
    }
}
