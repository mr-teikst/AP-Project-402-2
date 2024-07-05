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
using Final_Project.View.UserControls;
using Final_Project.ViewModels.UserControlsViewModel;

namespace Final_Project.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ResturantSearchItemUserControl.xaml
    /// </summary>
    public partial class ResturantSearchItemUserControl : UserControl
    {
        public ResturantSearchItemUserControl()
        {
            InitializeComponent();
            ResturantSearchItemViewModel vm = new ResturantSearchItemViewModel();
            DataContext = vm;
        }
    }
}
