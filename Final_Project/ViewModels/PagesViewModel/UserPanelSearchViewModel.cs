using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.MVVM;
using Final_Project.Views.UserControls;
using ApProject.Models;
using Final_Project.ViewModels.UserControlsViewModel;
using System.Windows.Controls;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class UserPanelSearchViewModel : ViewModelBase
    {

        public ObservableCollection<UserControl> ItemSourceFiels = new ObservableCollection<UserControl>();
        private List<ResturantSearchItemViewModel> _ItemSourceFielsViewModels;


        public UserPanelSearchViewModel() 
        {
            Resturant r1 = new Resturant("res1", "pass1", "res1", "tehran", "tehran markaz");
            Resturant r2 = new Resturant("res1", "pass1", "res1", "tehran", "tehran markaz");
            foreach (Resturant resturant in Resturant.Resturants )
            {
                ResturantSearchItemUserControl resturantItem = new ResturantSearchItemUserControl();
                ResturantSearchItemViewModel resturantSearchItemViewModel = new ResturantSearchItemViewModel() { ResturantNameField = resturant.Name};
                resturantItem.DataContext = resturantSearchItemViewModel;
                ItemSourceFiels.Add(resturantItem);
            }
        }
    }
}
