using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMobile.Model;
using ToDoMobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPageActive : ContentPage
    {
        public OrderPageActive()
        {
            InitializeComponent();
            BindingContext = new OrderPageVM(); 
        }

        private async void ActivePage_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AcceptOrderPage(e.SelectedItem as FullOrderDetails));
        }
    }
}