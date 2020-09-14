using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI_TeamHALM_Domain.Models
{
    public class Customers
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNo { get; set; }
    }
}
