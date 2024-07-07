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
    /// Interaction logic for FoodItemUserControl.xaml
    /// </summary>
    public partial class FoodItemUserControl : UserControl
    {
        public FoodItemUserControl(Food MainFood)
        {
            InitializeComponent();
            FoodItemViewModel vm = new FoodItemViewModel(MainFood);
            DataContext = vm;
        }
    }
}
