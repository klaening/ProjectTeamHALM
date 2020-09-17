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
        public ObservableCollection<Staff> StaffList { get; set; }
        public ObservableCollection<Departments> DepartmentList { get; set; }

        //Gör om till Department
        private string _selectedDepartment;
        public string SelectedDepartment
        {
            get { return _selectedDepartment; }
            set { SetProperty(ref _selectedDepartment, value); }
        }

        private Customers _selectedCustomer;
        public Customers SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        private Staff _selectedStaff;
        public Staff SelectedStaff
        {
            get => _selectedStaff;
            set => SetProperty(ref _selectedStaff, value);
        }

        private DateTimeOffset _selectedDate;
        public DateTimeOffset SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        private string _selectedOrderDescription;
        public string SelectedOrderDescription
        {
            get => _selectedOrderDescription;
            set => SetProperty(ref _selectedOrderDescription, value);
        }

        public ICommand SaveCommand { get; set; }

        public CreateOrder_InfoInput_VM()
        {
            SelectedDate = DateTimeOffset.Now;

            var result = Requests.GetRequest(Paths.Customers);
            var customers = JsonConvert.DeserializeObject<ObservableCollection<Customers>>(result);

            CustomerList = customers;

            result = Requests.GetRequest(Paths.Staff);
            var staff = JsonConvert.DeserializeObject<ObservableCollection<Staff>>(result);

            StaffList = staff;

            result = Requests.GetRequest(Paths.Departments);
            var departments = JsonConvert.DeserializeObject<ObservableCollection<Departments>>(result);

            DepartmentList = departments;
            SaveCommand = new RelayCommand(SaveWorkOrder, () => true);
        }

        private async void SaveWorkOrder()
        {
            WorkOrders workOrder = new WorkOrders
            {
                Description = SelectedOrderDescription,
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
