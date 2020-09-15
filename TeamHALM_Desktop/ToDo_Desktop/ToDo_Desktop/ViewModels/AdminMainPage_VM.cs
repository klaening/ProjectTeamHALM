using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Desktop.Models;
using ToDo_Desktop.Services;

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
            var result = Requests.GetRequest(Paths.FullOrderDetails);
            var orderInfo = JsonConvert.DeserializeObject<ObservableCollection<OrderInfo>>(result);

            OrderInfo = orderInfo;
        }


    }
}
