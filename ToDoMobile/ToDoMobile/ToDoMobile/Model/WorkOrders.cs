﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoMobile.Model
{
    public class WorkOrders
    {
        public int ID { get; set; }
        public string OrderDescription { get; set; }
        public DateTime StartingDate { get; set; }
        public string Commentary { get; set; }
        public decimal HoursSpent { get; set; }
        public decimal TravelTime { get; set; }
        public decimal ExtraCosts { get; set; }
        public int StaffID { get; set; }
        public int OrderStatusesID { get; set; }
        public int CustomersID { get; set; }
        public string OrderTitle { get; set; }
    }
}
