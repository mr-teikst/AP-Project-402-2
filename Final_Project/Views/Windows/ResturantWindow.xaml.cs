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
using Final_Project.ViewModels.WindowsViewModel;
using ApProject.Models;

namespace Final_Project.Views.Windows
{
    /// <summary>
    /// Interaction logic for ResturantWindow.xaml
    /// </summary>
    public partial class ResturantWindow : Window
    {
        public ResturantWindow(Resturant MainResturant)
        {
            InitializeComponent();
            ResturantWindowViewModel vm = new ResturantWindowViewModel(MainResturant);
            DataContext = vm;
        }
    }
}
