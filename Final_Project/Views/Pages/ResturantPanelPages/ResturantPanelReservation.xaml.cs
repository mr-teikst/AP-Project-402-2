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
using Final_Project.ViewModels.PagesViewModel;

namespace Final_Project.Views.Pages.ResturantPanelPages
{
    /// <summary>
    /// Interaction logic for ResturantPanelReservation.xaml
    /// </summary>
    public partial class ResturantPanelReservation : Page
    {
        public ResturantPanelReservation()
        {
            InitializeComponent();
            ResturantPanelReservationViewModel vm = new ResturantPanelReservationViewModel();
            DataContext = vm;
        }
    }
}
