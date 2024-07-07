using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApProject.Models;
using Final_Project.ViewModels.UserControlsViewModel;

namespace Final_Project.Views.UserControls
{
    /// <summary>
    /// Interaction logic for OrderItemUserControl.xaml
    /// </summary>
    public partial class OrderItemUserControl : UserControl
    {
        public OrderItemUserControl(Food food, int foodCount)
        {
            InitializeComponent();
            OrderItemViewModel vm = new OrderItemViewModel(food, foodCount);
            DataContext = vm;
        }
    }
}
