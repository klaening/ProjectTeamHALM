using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Desktop.Models;

namespace ToDo_Desktop.ViewModels
{
 
    public class AdminMainPage_VM : BindableBase
    {
        // Klassen ska ärva från en klass bindableBase som i sin tur ärver från InotifyPropertChanged
        // Detta finns i Prague Parking.

        //Mockup data för order

        private ObservableCollection<Order> orderCollection = new ObservableCollection<Order>();

        private Order selectedOrder;
        public ObservableCollection<Order> OrderCollection { get { return this.orderCollection; } }

        public Order SelectedOrder
        {
            get => selectedOrder;
            set => SetProperty(ref selectedOrder, value);
        }

        public AdminMainPage_VM()
        {
            this.OrderCollection.Add(new Order() { OrderID = "1001", Adress = "Johanvägen 1", Operator = "Johans schakt", Time = "08:00 19/10", WorkTask = "Gräva en grop", ContactDetails = "0701234567 - Anders", Status = "Pending" });
            this.OrderCollection.Add(new Order() { OrderID = "1002", Adress = "Petervägen 20", Operator = "Peters Tvätt", Time = "10:30 1/02", WorkTask = "Tvätta tio bilar", ContactDetails = "0760239584 - Tobias", Status = "Accepted" });
            this.OrderCollection.Add(new Order() { OrderID = "1003", Adress = "Jörlins Gata 14", Operator = "Tildas Gräsklipp", Time = "06:00 14/7", WorkTask = "Klippa gräsmattan", ContactDetails = "0704812658- Karin", Status = "Completed" });
            this.OrderCollection.Add(new Order() { OrderID = "1004", Adress = "Hussparven 27", Operator = "Nilssons Djurfång", Time = "23:30 1/1", WorkTask = "Fånga bävern", ContactDetails = "0701121121- Knut", Status = "Sent" });



        }


    }
}
