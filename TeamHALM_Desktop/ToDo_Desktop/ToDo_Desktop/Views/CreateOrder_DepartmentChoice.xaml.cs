using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ToDo_Desktop.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDo_Desktop.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateOrder_DepartmentChoice : Page
    {
        private readonly CreateOrder_DepartmentChoice_VM _viewModel;
        public CreateOrder_DepartmentChoice()
        {
            this.InitializeComponent();
            _viewModel = new CreateOrder_DepartmentChoice_VM();
            DataContext = _viewModel;
        }

        private void Elektriker_Btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateOrder_InfoInput));
        }

        private void Snickare_Btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateOrder_InfoInput));
        }

        private void VvS_Btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateOrder_InfoInput));
        }

        private void Return_Btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
