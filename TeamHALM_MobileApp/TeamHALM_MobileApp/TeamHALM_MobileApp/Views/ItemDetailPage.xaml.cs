using System.ComponentModel;
using Xamarin.Forms;
using TeamHALM_MobileApp.ViewModels;

namespace TeamHALM_MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}