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
using ToDo_Desktop.ExtensionMethods;
using ToDo_Desktop.Models;
using ToDo_Desktop.Services;
using Windows.UI.Popups;

namespace ToDo_Desktop.ViewModels
{
    public class EditOrderPage_VM : BindableBase
    {
        private NavigationService _navigationService;
        public ObservableCollection<Staff> StaffList { get; set; }
        public ObservableCollection<Customers> CustomerList { get; set; }
        public ObservableCollection<OrderStatuses> StatusList { get; set; }
        public OrderInfo OriginalOrder { get; set; }

        private OrderInfo _selectedOrder;
        public OrderInfo SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
                //ChangesMade = true;
            }
        }

        private Staff _selectedStaff;
        public Staff SelectedStaff
        {
            get => _selectedStaff;
            set
            {
                //SelectedOrder.StaffID måste sättas till _selectedStaff
                SetProperty(ref _selectedStaff, value);
                //ChangesMade = true;
            }
        }

        private Customers _selectedCustomer;
        public Customers SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                SetProperty(ref _selectedCustomer, value);
                //ChangesMade = true;
                //SelectedOrder.CustomerName = _selectedCustomer.CustomerName;
                //SelectedOrder.CustomerAddress = _selectedCustomer.CustomerAddress;
                //SelectedOrder.CustomerPhoneNo = _selectedCustomer.CustomerPhoneNo;
            }
        }

        private OrderStatuses _selectedStatus;
        public OrderStatuses SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                SetProperty(ref _selectedStatus, value);
                //ChangesMade = true;
            }
        }


        //private bool _changesMade;
        //public bool ChangesMade 
        //{
        //    get => _changesMade;
        //    set 
        //    {
        //        if (CheckChanges())
        //            SetProperty(ref _changesMade, value);
        //        else
        //            SetProperty(ref _changesMade, false);
        //    }
        //}

        //private bool CheckChanges()
        //{
        //    //Kolla alla Selected ifall det har blivit ändringar 
        //    //Skapa en kopia på originalOrdern?
        //    //Isf kan vi ha en Resetknapp
        //    //Jämför den nya med originalet

        //    if (!_selectedOrder.Equals(OriginalOrder))
        //        return true;
        //    else
        //        return false;
        //}

        public ICommand SaveCommand { get; set; }

        public EditOrderPage_VM()
        {
            _navigationService = new NavigationService();

            var result = Requests.GetRequest(Paths.Staff);
            StaffList = JsonConvert.DeserializeObject<ObservableCollection<Staff>>(result);

            result = Requests.GetRequest(Paths.OrderStatuses);
            StatusList = JsonConvert.DeserializeObject<ObservableCollection<OrderStatuses>>(result);

            result = Requests.GetRequest(Paths.Customers);
            CustomerList = JsonConvert.DeserializeObject<ObservableCollection<Customers>>(result);

            SaveCommand = new RelayCommand(SaveChanges, () => true);
        }

        private async void SaveChanges()
        {
            var workOrder = new WorkOrders
            {
                ID = SelectedOrder.ID,
                OrderDescription = SelectedOrder.OrderDescription,
                StartingDate = SelectedOrder.StartingDate,
                Commentary = SelectedOrder.Commentary,
                HoursSpent = SelectedOrder.HoursSpent,
                TravelTime = SelectedOrder.TravelTime,
                ExtraCosts = SelectedOrder.ExtraCosts,
                StaffID = SelectedStaff.ID,
                OrderStatusesID = SelectedStatus.ID,
                CustomersID = SelectedCustomer.ID
            };

            try
            {
                var response = await Requests.PutRequestAsync(Paths.WorkOrders, workOrder);
                var statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var dialog = new MessageDialog("Work order successfully updated", "Success");
                    await dialog.ShowAsync();

                    _navigationService.GoBack();
                }
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong", "Error");
                await dialog.ShowAsync();
            }
        }
    }
}
