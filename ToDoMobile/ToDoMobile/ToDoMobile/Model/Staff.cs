using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoMobile.Model
{
    public class Staff
    {
        public int ID { get; set; }
        public string StaffName { get; set; }

        //Foreign Key
        public int DepartmentsID { get; set; }
    }
}
