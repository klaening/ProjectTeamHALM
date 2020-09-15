using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ToDoMobile.Model;
using ToDoMobile.Services;
using ToDoMobile.Utility;

namespace ToDoMobile.ViewModel
{
    public class OrderPageVM : BaseViewModel
    {
        private ObservableCollection<WorkOrders> _pendingList;
        public ObservableCollection<WorkOrders> PendingList
        {
            get => _pendingList;
            set
            {
                _pendingList = value;
                OnPropertyChanged("PendingList");
            }
        }

        private ObservableCollection<WorkOrders> _activeList;
        public ObservableCollection<WorkOrders> ActiveList
        {
            get => _activeList;
            set
            {
                _activeList = value;
                OnPropertyChanged("ActiveList");

            }
        }

        //public ObservableCollection<WorkOrders> CreateMockData()
        //{
        //    var TestList = new ObservableCollection<WorkOrders>();
        //    var OrderOne = new WorkOrders { ID = 1, Description = "Broken Dishwasher", OrderStatusesID = 1 };
        //    var OrderTwo = new WorkOrders { ID = 2, Description = "Broken elevator", OrderStatusesID = 2 };

        //    TestList.Add(OrderOne);
        //    TestList.Add(OrderTwo);
        //    return TestList;
        //}

        public OrderPageVM()
        {
            PendingList = new ObservableCollection<WorkOrders>();
            ActiveList = new ObservableCollection<WorkOrders>();
            var response = APIServices.GetRequest(ApiPaths.WorkOrders);

            var tempList = JsonConvert.DeserializeObject<ObservableCollection<WorkOrders>>(response);


            foreach (var order in tempList)
            {
                
                if(order.OrderStatusesID == (int)StatusNameEnum.Pending)
                    PendingList.Add(order);
                if (order.OrderStatusesID == (int)StatusNameEnum.Accepted || order.OrderStatusesID == (int)StatusNameEnum.Completed)
                    ActiveList.Add(order);
            }

        }
    }
}
