using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Final_Project.View.UserControls;

namespace Final_Project.Views.Pages.UserPanelPages
{
    /// <summary>
    /// Interaction logic for UserPanelSearch.xaml
    /// </summary>
    public partial class UserPanelSearch : Page
    {
        public UserPanelSearch()
        {
            InitializeComponent();
            UserPanelSearchViewModel vm = new UserPanelSearchViewModel();
            DataContext = vm;


            //ObservableCollection<UserControl> items_sours = new ObservableCollection<UserControl>();
            //items_sours.Add(new TextInput());
            //.Add(new TextInput());
            //items_sours.Add(new TextInput());
            //items_sours.Add(new TextInput());
            //li.ItemsSource = items_sours;

        }
    }
}
