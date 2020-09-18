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
using Windows.UI.Xaml.Controls;

namespace ToDo_Desktop.ViewModels
{
    public class CreateOrder_InfoInput_VM : BindableBase
    {
        public NavigationService _navigationService { get; set; }
        public ObservableCollection<Customers> CustomerList { get; set; }

        private ObservableCollection<Staff> _staffList;
        public ObservableCollection<Staff> StaffList 
        {
            get => _staffList;
            set => SetProperty(ref _staffList, value);
        }
        public ObservableCollection<Departments> DepartmentList { get; set; }

        private int _btnID;
        public int BtnID 
        { 
            get => _btnID;
            set 
            {
                SetProperty(ref _btnID, value);
                SelectedDepartment = DepartmentList.FirstOrDefault(x => x.ID == _btnID);
            }
        }

        //Gör om till Department
        private Departments _selectedDepartment;
        public Departments SelectedDepartment
        {
            get => _selectedDepartment;
            set
            {
                SetProperty(ref _selectedDepartment, value);
                StaffList = StaffList.Where(x => x.DepartmentsID == _selectedDepartment.ID).MakeObservable();
            } 
        }

        private Customers _selectedCustomer;
        public Customers SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                SetProperty(ref _selectedCustomer, value);
                MultiCheck = true;
            }
        }

        private Staff _selectedStaff;
        public Staff SelectedStaff
        {
            get => _selectedStaff;
            set
            {
                SetProperty(ref _selectedStaff, value);
                MultiCheck = true;
            }
        }

        private DateTimeOffset _selectedDate;
        public DateTimeOffset SelectedDate
        {
            get => _selectedDate;
            set
            {
                SetProperty(ref _selectedDate, value);
                MultiCheck = true;
            }
        }

        private string _selectedOrderDescription;
        public string SelectedOrderDescription
        {
            get => _selectedOrderDescription;
            set 
            {
                SetProperty(ref _selectedOrderDescription, value);
                MultiCheck = true;
            } 
        }

        private bool _multiCheck;
        public bool MultiCheck
        {
            get => _multiCheck;
            set
            {
                if (_selectedCustomer == null || _selectedStaff == null || _selectedDate == null || string.IsNullOrWhiteSpace(_selectedOrderDescription))
                    SetProperty(ref _multiCheck, false);
                else
                    SetProperty(ref _multiCheck, value);
            }
        }

        public ICommand SaveCommand { get; set; }

        public CreateOrder_InfoInput_VM()
        {
            _navigationService = new NavigationService();

            SelectedDate = DateTimeOffset.Now;

            var result = Requests.GetRequest(Paths.Customers);
            var customers = JsonConvert.DeserializeObject<ObservableCollection<Customers>>(result);

            result = Requests.GetRequest(Paths.Staff);
            var staff = JsonConvert.DeserializeObject<ObservableCollection<Staff>>(result);

            result = Requests.GetRequest(Paths.Departments);
            var departments = JsonConvert.DeserializeObject<ObservableCollection<Departments>>(result);

            CustomerList = customers;
            
            StaffList = staff;
            
            DepartmentList = departments;

            SaveCommand = new RelayCommand(SaveWorkOrder, () => true);
        }

        private async void SaveWorkOrder()
        {
            WorkOrders workOrder = new WorkOrders
            {
                OrderDescription = SelectedOrderDescription,
                StartingDate = SelectedDate.UtcDateTime,
                StaffID = SelectedStaff.ID,
                OrderStatusesID = 1,
                CustomersID = SelectedCustomer.ID
            };

            try
            {
                var response = await Requests.PostRequestAsync(Paths.WorkOrders, workOrder);
                var statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var dialog = new MessageDialog("Work order successfully saved", "Success");
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
