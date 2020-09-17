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

namespace ToDo_Desktop.ViewModels
{
 
    public class AdminMainPage_VM : BindableBase
    {
        private NavigationService navigationService;

        private ObservableCollection<OrderInfo> _orderInfo = new ObservableCollection<OrderInfo>();
        private OrderInfo _selectedOrderInfo;

        public ObservableCollection<OrderInfo> OrderInfo
        {
            get => _orderInfo;
            set => SetProperty(ref _orderInfo, value);
        }

        public OrderInfo SelectedOrderInfo
        {
            get => _selectedOrderInfo;
            set => SetProperty(ref _selectedOrderInfo, value);
        }

        public AdminMainPage_VM()
        {
            navigationService = new NavigationService();

            UpdateOrderList();

            DeleteCommand = new RelayCommand(DeleteWorkOrder, () => true);
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

        private void UpdateOrderList()
        {
            var result = Requests.GetRequest(Paths.FullOrderDetails);
            OrderInfo = JsonConvert.DeserializeObject<ObservableCollection<OrderInfo>>(result);
        }
    }
}
