using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : TabbedPage
    {
        public OrderPage()
        {
            InitializeComponent();
            BindingContext = new OrderPageVM();

            var c = Color.FromHex("#1e1e23");
            this.BarBackgroundColor = c;
            
        }
    }
}