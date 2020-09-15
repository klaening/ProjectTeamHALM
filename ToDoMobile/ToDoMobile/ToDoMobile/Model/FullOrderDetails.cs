using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoMobile.Model
{
    public class FullOrderDetails
    {
        public int ID { get; set; }
        public string OrderDescription { get; set; }
        public DateTime StartingDate  { get; set; } 
        public string Commentary { get; set; } 
        public decimal HoursSpent { get; set; } 
        public decimal TravelTime { get; set; } 
        public decimal ExtraCosts { get; set; } 
        public string StaffName { get; set; } 
        public string DepartmentName { get; set; } 
        public string StatusName { get; set; } 
        public string CustomerName { get; set; } 
        public string CustomerAddress { get; set; } 
        public string CustomerPhoneNo { get; set; }
    }
}
