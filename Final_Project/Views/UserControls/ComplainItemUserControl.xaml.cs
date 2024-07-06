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
using Final_Project.ViewModels.UserControlsViewModel;

namespace Final_Project.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ComplainItemUserControl.xaml
    /// </summary>
    public partial class ComplainItemUserControl : UserControl
    {
        public ComplainItemUserControl()
        {
            InitializeComponent();
            ComplainItemViewModel vm = new ComplainItemViewModel();
            DataContext = vm;
        }
    }
}
