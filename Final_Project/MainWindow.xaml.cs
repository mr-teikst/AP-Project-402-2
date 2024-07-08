using Final_Project.ViewModels;
using Final_Project.Views;
using Final_Project.Views.Pages;
using Final_Project.Views.Pages.UserPanelPages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Final_Project.Views.Windows;
using Final_Project.Views.Pages.ResturantPanelPages;
using ApProject.Models;

namespace Final_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            User.LoadFromJsonFile();
            InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;
            
            //OrderBox ob = new OrderBox();
            //ob.Show();
            //ResturantWindow rv = new ResturantWindow();
            //rv.Show();
        }

    }
}