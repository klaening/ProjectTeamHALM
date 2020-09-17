using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo_Desktop.Models;
using ToDo_Desktop.Services;
using Windows.UI.Xaml;

namespace ToDo_Desktop.ViewModels
{
 
    public class AdminMainPage_VM : BindableBase
    {
        private Visibility isVisible = Visibility.Collapsed;
        

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
            set 
            { 
                SetProperty(ref _selectedOrderInfo, value);
                IsVisible = Visibility.Visible;
            }
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
                {
                    
                    SetProperty(ref isVisible, value);

                }

            }
        }

        //Gör om SelectedOrder till en order.

        public ICommand AcceptCommand { get; set; }

        private void AcceptOrder() // ska vara async eftersom put requesten är await
        {
            // put request med id från selectedorder
     
        }

        public AdminMainPage_VM()
        {
            navigationService = new NavigationService();
            var result = Requests.GetRequest(Paths.FullOrderDetails);
            var orderInfo = JsonConvert.DeserializeObject<ObservableCollection<OrderInfo>>(result);

            OrderInfo = orderInfo;

            AcceptCommand = new RelayCommand(AcceptOrder, () => true);
        }


    }
}
