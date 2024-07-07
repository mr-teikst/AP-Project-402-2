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
using System.Windows.Shapes;
using ApProject.Models;
using Final_Project.ViewModels.WindowsViewModel;

namespace Final_Project.Views.Windows
{
    /// <summary>
    /// Interaction logic for OrderBox.xaml
    /// </summary>
    public partial class OrderBox : Window
    {
        public OrderBox(List<Food> foods)
        {
            InitializeComponent();
            OrderBoxViewModel vm = new OrderBoxViewModel(foods, this);
            DataContext = vm;
        }
    }
}
