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

        public TextInputViewModel NameSearchUCVM { get; set; }
        public TextInputViewModel CitySearchUCVM { get; set; }
        public TextInputViewModel RateSearchUCVM { get; set; }
        public TextInputViewModel Dine_inSearchUCVM { get; set; }



        public UserPanelSearchViewModel() 
        {
            NameSearchUCVM = new TextInputViewModel() { NameField = "Name" };
            CitySearchUCVM = new TextInputViewModel() { NameField = "City" };
            RateSearchUCVM = new TextInputViewModel() { NameField = "Rate" };
            Dine_inSearchUCVM = new TextInputViewModel() { NameField = "Reserve" };
            BuildCollection(Resturant.Resturants);
        }
        public RelayCommand ApplyBTNCommand => new RelayCommand(execute => ApplyFunc());

        private void ApplyFunc()
        {
            var resturants = Resturant.Resturants;
            if (NameSearchUCVM.TextField != "")
            {
                resturants = Resturant.SearchByRestaurantName(NameSearchUCVM.TextField, resturants);
            }
            if (CitySearchUCVM.TextField != "")
            {
                resturants = Resturant.SearchByCity(CitySearchUCVM.TextField, resturants);
            }
            if (RateSearchUCVM.TextField != "")
            {
                double rate;
                try
                {
                    rate = double.Parse(RateSearchUCVM.TextField);
                    if (rate < 0 || rate > 5) throw new Exception();
                    RateSearchUCVM.HintField = "";
                    resturants = Resturant.SearchByMinimumRating(rate, resturants);
                }
                catch
                {
                    RateSearchUCVM.HintField = "Invalid input (0 <= rate <= 5)";
                }
            }
            if (Dine_inSearchUCVM.TextField != "")
            {
                bool state;
                try
                {
                    state = Dine_inSearchUCVM.TextField.ToLower() == "yes"? true: false;
                    if (Dine_inSearchUCVM.TextField.ToLower() != "yes" && Dine_inSearchUCVM.TextField.ToLower() != "no") throw new Exception();
                    Dine_inSearchUCVM.HintField = "";
                    resturants = Resturant.SearchByDine_in(state, resturants);
                }
                catch
                {
                    Dine_inSearchUCVM.HintField = "Invalid input (yse|no)";
                }
            }
            BuildCollection(resturants);
        }


        private void BuildCollection(List<Resturant> resturants)
        {
            ItemSourceField.Clear();
            foreach (Resturant resturant in resturants)
            {
                resturant.CalculateRestaurantAverageRating();
                ResturantSearchItemUserControl resturantItem = new ResturantSearchItemUserControl();
                ResturantSearchItemViewModel resturantSearchItemViewModel = new ResturantSearchItemViewModel()
                {
                    ResturantNameField = resturant.Name,
                    AddressField = resturant.Address,
                    ReservationStatusField = resturant.ActiveReserve ? "Reservation: Avalable" : "Reservation: UnAvalable",
                    RateField = "Rate: " + resturant.Rating.ToString(),
                    ResturantField = resturant
                };
                resturantItem.DataContext = resturantSearchItemViewModel;
                ItemSourceField.Add(resturantItem);
            }
        }


    }
}
