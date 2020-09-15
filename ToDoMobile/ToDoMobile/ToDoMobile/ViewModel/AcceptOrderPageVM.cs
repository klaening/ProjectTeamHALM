using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Text;
using System.Windows.Input;
using ToDoMobile.Model;
using ToDoMobile.Utility;
using Xamarin.Forms;
using ToDoMobile.Services;
using ToDoMobile.View;

namespace ToDoMobile.ViewModel
{
    class AcceptOrderPageVM : BaseViewModel
    {
        public ICommand AcceptCommand { get; }
        public INavigation Navigation { get; set; }

        public ObservableCollection<OrderStatuses> Statuses { get; set; }
        private string _buttonText;
        public string ButtonText
        {
            get
            {
                if (SelectedOrder != null)
                {
                    if(SelectedOrder.OrderStatusesID == (int)StatusNameEnum.Accepted || SelectedOrder.OrderStatusesID == (int)StatusNameEnum.Completed)
                    {
                        return "Done";
                    }
                    return "Accept";
                }
                return "";
            }
            set
            {
                _buttonText = value;
                OnPropertyChanged("ButtonText");

            }
        }

        private WorkOrders _selectedOrder;
        public WorkOrders SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
                OnPropertyChanged("ButtonText");

            }
        }

        public AcceptOrderPageVM()
        {
            AcceptCommand = new Command(AcceptPressedCommand);

            var response = APIServices.GetRequest(ApiPaths.OrderStatuses);
            Statuses = JsonConvert.DeserializeObject<ObservableCollection<OrderStatuses>>(response);
        }

        public void AcceptPressedCommand()
        {
            var order = GetOrderFromID();
            UpdateOrder(order);

            SelectedOrder.OrderStatusesID = order.OrderStatusesID;
            OnPropertyChanged("ButtonText");

            if(order.OrderStatusesID == (int)StatusNameEnum.Accepted || order.OrderStatusesID == (int)StatusNameEnum.Completed)
            {
                Navigation.PushAsync(new OrderPage());
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Accepted","Order status have been updated!","Ok");
            }
        }

        public WorkOrders GetOrderFromID()
        {
            string source = SelectedOrder.OrderStatusesID.ToString();
            var response = APIServices.GetRequest(ApiPaths.WorkOrders, source);
            var order = JsonConvert.DeserializeObject<WorkOrders>(response);
            return order;
        }

        public async void UpdateOrder(WorkOrders order)
        {
            order.OrderStatusesID += 1;
            await APIServices.PutRequestAsync(ApiPaths.WorkOrders, order);
        }
    }
}
