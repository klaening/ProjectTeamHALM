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
                    if(SelectedOrder.StatusName == StatusNameEnum.Accepted.ToString() || SelectedOrder.StatusName == StatusNameEnum.Completed.ToString())
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

        private FullOrderDetails _selectedOrder;
        public FullOrderDetails SelectedOrder
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

            SelectedOrder.StatusName = order.StatusName;
            OnPropertyChanged("ButtonText");

            if(order.StatusName == StatusNameEnum.Accepted.ToString() || order.StatusName == StatusNameEnum.Completed.ToString())
            {
                Navigation.PushAsync(new OrderPage());
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Accepted","Order status have been updated!","Ok");
            }
        }

        public FullOrderDetails GetOrderFromID()
        {
            string source = SelectedOrder.ID.ToString();
            var response = APIServices.GetRequest(ApiPaths.FullOrderDetails, source);
            var order = JsonConvert.DeserializeObject<FullOrderDetails>(response);
            return order;
        }

        public async void UpdateOrder(FullOrderDetails order)
        {
            order.StatusName += 1;
            await APIServices.PutRequestAsync(ApiPaths.FullOrderDetails, order);
        }
    }
}
