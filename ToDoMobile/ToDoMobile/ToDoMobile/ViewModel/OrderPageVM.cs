using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ToDoMobile.Model;
using ToDoMobile.Utility;

namespace ToDoMobile.ViewModel
{
    public class OrderPageVM : BaseViewModel
    {
        private ObservableCollection<WorkOrders> _pendingList;
        public ObservableCollection<WorkOrders> PendingList
        {
            get { return CreateMockData(); }
            set
            {
                _pendingList = value;
                
            }
        }

        public ObservableCollection<WorkOrders> CreateMockData()
        {
            var TestList = new ObservableCollection<WorkOrders>();
            var OrderOne = new WorkOrders { ID = 1, Description = "Broken Dishwasher", OrderStatusesID = 1 };
            var OrderTwo = new WorkOrders { ID = 2, Description = "Broken elevator", OrderStatusesID = 2 };

            TestList.Add(OrderOne);
            TestList.Add(OrderTwo);
            return TestList;
        }

        //public OrderPageVM()
        //{
        //    PendingList = new ObservableCollection<WorkOrders>();

        //    foreach (var order in PendingList)
        //    {
        //       order.OrderStatusesID == (int)StatusNameEnum.Pending
        //            PendingList.Add(order);
        //    }

        //}
    }
}
