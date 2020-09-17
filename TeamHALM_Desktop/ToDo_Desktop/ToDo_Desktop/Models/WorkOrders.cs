using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Desktop.Models
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
    }
}
