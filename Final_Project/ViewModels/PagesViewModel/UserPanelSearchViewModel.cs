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

        private ObservableCollection<UserControl> _ItemSourceField = new ObservableCollection<UserControl>();
        public ObservableCollection<UserControl> ItemSourceField
        {
            get { return _ItemSourceField; }
            set { _ItemSourceField = value; }
        }

        private List<ResturantSearchItemViewModel> _ItemSourceFielsViewModels;


        public UserPanelSearchViewModel() 
        {
            ItemSourceField.Clear();
            foreach (Resturant resturant in Resturant.Resturants )
            {
                ResturantSearchItemUserControl resturantItem = new ResturantSearchItemUserControl();
                ResturantSearchItemViewModel resturantSearchItemViewModel = new ResturantSearchItemViewModel()
                { 
                    ResturantNameField = resturant.Name,
                    AddressField = resturant.Address,
                    ReservationStatusField = resturant.CanReserve ? "Reservation: Avalable" : "Reservation: UnAvalable",
                    RateField = resturant.Rating.ToString()
                };
                resturantItem.DataContext = resturantSearchItemViewModel;
                ItemSourceField.Add(resturantItem);
            }
        }
    }
}
