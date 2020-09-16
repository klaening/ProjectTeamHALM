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
    public class CreateOrder_InfoInput_VM : BindableBase
    {
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
            //DeleteCommand = new RelayCommand(DeleteTicketCommand, () => true);
        }
    }
}
