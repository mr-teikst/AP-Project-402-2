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
using Final_Project.ViewModels;
using Final_Project.ViewModels.PagesViewModel;

namespace Final_Project.Views.Pages.UserPanelPages
{
    /// <summary>
    /// Interaction logic for UserPanelHistory.xaml
    /// </summary>
    public partial class UserPanelHistory : Page
    {
        public UserPanelHistory()
        {
            InitializeComponent();
            UserPanelHistoryViewModel vm = new UserPanelHistoryViewModel();
            DataContext = vm;
        }
    }
}
