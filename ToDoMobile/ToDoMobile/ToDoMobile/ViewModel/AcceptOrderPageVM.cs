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
using System.Net;
using Microsoft.Azure.NotificationHubs;

namespace ToDoMobile.ViewModel
{
    class AcceptOrderPageVM : BaseViewModel
    {
        public ICommand AcceptCommand { get; }
        public ICommand DeclineCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand CompleteCommand { get; }
        public INavigation Navigation { get; set; }

        public ObservableCollection<OrderStatuses> Statuses { get; set; }
        private string _buttonText;
        public string ButtonText
        {
            get
            {
                if (SelectedOrder != null)
                {
                    if (SelectedOrder.StatusName == StatusNameEnum.Pending.ToString())
                    {
                        return "Accept";
                    }
                    if(SelectedOrder.StatusName == StatusNameEnum.Accepted.ToString())
                    {
                        return "Done";
                    }
                    if (SelectedOrder.StatusName == StatusNameEnum.Review.ToString())
                    {
                       
                        return "Send";
                    }
                }
                return _buttonText;
            }

            set
            {
                _buttonText = value;
                OnPropertyChanged("ButtonText");

            }
        }

        private decimal extraCostText;
        public decimal ExtraCostText
        {
            get { return extraCostText; }
            set { 
                
                extraCostText = value;
                OnPropertyChanged("ExtraCostText");

                }
        }

        private decimal travelTimeText;
        public decimal TravelTimeText
        {
            get { return travelTimeText; }
            set { travelTimeText = value;
                OnPropertyChanged("TravelTimeText");
            }
        }

        private decimal hoursSpentText;
        public decimal HoursSpentText
        {
            get { return hoursSpentText; }
            set { hoursSpentText = value;
                OnPropertyChanged("HoursSpentText");
            }
        }

        private string commentaryText;
        public string CommentaryText
        {
            get { return commentaryText; }
            set { commentaryText = value;
                OnPropertyChanged("CommentaryText");
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
            DeclineCommand = new Command(DeclinePressedCommand);
            AcceptCommand = new Command(AcceptPressedCommand);
            UndoCommand = new Command(UndoOrderPressedCommand);
            CompleteCommand = new Command(CompleteOrderPressedCommand);

            var response = APIServices.GetRequest(ApiPaths.OrderStatuses);
            Statuses = JsonConvert.DeserializeObject<ObservableCollection<OrderStatuses>>(response);
        }

        public void AcceptPressedCommand()
        {
            var order = GetOrderFromID();
            UpdateOrder(order);

            SelectedOrder.StatusName = order.StatusName;
            OnPropertyChanged("ButtonText");

            if(order.StatusName == StatusNameEnum.Pending.ToString() || order.StatusName == StatusNameEnum.Completed.ToString())
            {
                Navigation.PushAsync(new OrderPage());
            }
            //else
            //{
            //    Application.Current.MainPage.DisplayAlert("Accepted","Order status have been updated!","Ok");
            //}
        }
        public void DeclinePressedCommand()
        {
            var order = GetOrderFromID();
            DeclineOrder(order);
            Application.Current.MainPage.DisplayAlert("Declined", "You have declined the order"+order.OrderTitle, "ok");
            Navigation.PushAsync(new OrderPage());
        }
        public void UndoOrderPressedCommand()
        {
            var order = GetOrderFromID();
            UndoAcceptedOrder(order);
            Application.Current.MainPage.DisplayAlert("Undo Accepted Order", "Your order is now set back to Pending", "ok");
            Navigation.PushAsync(new OrderPage());
        }
        public void CompleteOrderPressedCommand()
        {
            var order = GetOrderFromID();
            CompleteAcceptedOrder(order);
            Navigation.PushAsync(new OrderPage());
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
            if (order.OrderStatusesID == 1)
            {
               

                WorkOrders workOrders = new WorkOrders
                {
                    ID = order.ID,
                    StaffID = order.StaffID,
                    StartingDate = order.StartingDate,
                    CustomersID = order.CustomersID,
                    OrderDescription = order.OrderDescription,
                    OrderStatusesID = 2,
                    OrderTitle = order.OrderTitle

                };
                await APIServices.PutRequestAsync(ApiPaths.WorkOrders, workOrders);
                SendTemplateNotificationAsync(workOrders, "  New status:  Accepted");
            }

            else if (order.OrderStatusesID == 2)
            {
              await Application.Current.MainPage.DisplayAlert("Done", "Please enter additional information to finish the order", "Ok");

            }
            else
            {

            }
        }   
        public async void DeclineOrder(FullOrderDetails order)
        {
            WorkOrders workOrders = new WorkOrders
            {
                ID = order.ID,
                StaffID = order.StaffID,
                StartingDate = order.StartingDate,
                CustomersID = order.CustomersID,
                OrderDescription = order.OrderDescription,
                OrderStatusesID = 3,
                OrderTitle = order.OrderTitle
                
                
            };
            await APIServices.PutRequestAsync(ApiPaths.WorkOrders, workOrders);
            SendTemplateNotificationAsync(workOrders, "  New status :  Declined");
        }
        public async void UndoAcceptedOrder(FullOrderDetails order)
        {
            WorkOrders workOrders = new WorkOrders
            {
                ID = order.ID,
                StaffID = order.StaffID,
                StartingDate = order.StartingDate,
                CustomersID = order.CustomersID,
                OrderDescription = order.OrderDescription,
                OrderStatusesID = 1,
                OrderTitle = order.OrderTitle

            };
            await APIServices.PutRequestAsync(ApiPaths.WorkOrders, workOrders);
            SendTemplateNotificationAsync(workOrders, "  New status:  Pending");

        }
        public async void CompleteAcceptedOrder(FullOrderDetails order)
        {
            WorkOrders workOrders = new WorkOrders
            {
                ID = order.ID,
                StaffID = order.StaffID,
                StartingDate = order.StartingDate,
                CustomersID = order.CustomersID,
                OrderDescription = order.OrderDescription,
                OrderStatusesID = 4,
                OrderTitle = order.OrderTitle,
                Commentary = CommentaryText,
                HoursSpent = HoursSpentText,
                ExtraCosts = ExtraCostText,
                TravelTime = travelTimeText
               
            };
            await APIServices.PutRequestAsync(ApiPaths.WorkOrders, workOrders);

            SendTemplateNotificationAsync(workOrders, "  New status :  Completed");
        }

        private static async void SendTemplateNotificationAsync(WorkOrders work, string status)
        {
            // Define the notification hub.
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://teamhalmtestnotification.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=vj6kMiukDeWJm7DcY+t6GWAoVJI800JecK7pqiaOGeY=", "TeamHalmTestNotification");

            string toastStart = @"<toast><visual><binding template=""ToastText01""><text id=""1"">";
            string toastMiddle = work.OrderTitle + status;
            string toastEnd = "</text></binding></visual></toast>";
            string toastbuilder = toastStart + toastMiddle + toastEnd;
            await hub.SendWindowsNativeNotificationAsync(toastbuilder);
        }
    }
}
