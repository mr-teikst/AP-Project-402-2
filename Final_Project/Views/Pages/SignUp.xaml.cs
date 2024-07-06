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
using Final_Project;
using Final_Project.ViewModels.PagesViewModel;
using Final_Project.ViewModels;
namespace Final_Project.Views.Pages
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp(MainWindowViewModel mw)
        {
            InitializeComponent();
            SignUpViewModel vm = new SignUpViewModel(mw);
            DataContext = vm;
        }
    }
}
