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
        private ObservableCollection<FullOrderDetails> _pendingList;
        public ObservableCollection<FullOrderDetails> PendingList
        {
            get => _pendingList;
            set
            {
                _pendingList = value;
                OnPropertyChanged("PendingList");
            }
        }

        private ObservableCollection<FullOrderDetails> _activeList;
        public ObservableCollection<FullOrderDetails> ActiveList
        {
            get => _activeList;
            set
            {
                _activeList = value;
                OnPropertyChanged("ActiveList");

            }
        }

        //public ObservableCollection<FullOrderDetails> CreateMockData()
        //{
        //    var TestList = new ObservableCollection<FullOrderDetails>();
        //    var OrderOne = new FullOrderDetails { ID = 1, Description = "Broken Dishwasher", OrderStatusesID = 1 };
        //    var OrderTwo = new FullOrderDetails { ID = 2, Description = "Broken elevator", OrderStatusesID = 2 };

        //    TestList.Add(OrderOne);
        //    TestList.Add(OrderTwo);
        //    return TestList;
        //}

        public OrderPageVM()
        {
            PendingList = new ObservableCollection<FullOrderDetails>();
            ActiveList = new ObservableCollection<FullOrderDetails>();
            var response = APIServices.GetRequest(ApiPaths.FullOrderDetails);

            var tempList = JsonConvert.DeserializeObject<ObservableCollection<FullOrderDetails>>(response);


            foreach (var order in tempList)
            {
                
                if(order.StatusName == StatusNameEnum.Pending.ToString())
                    PendingList.Add(order);
                if (order.StatusName == StatusNameEnum.Accepted.ToString() || order.StatusName == StatusNameEnum.Completed.ToString())
                    ActiveList.Add(order);
            }

        }
    }
}
