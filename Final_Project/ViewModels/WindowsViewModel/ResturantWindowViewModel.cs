using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.ViewModels.UserControlsViewModel;
using Final_Project.Views.UserControls;
using Final_Project.ViewModels.PagesViewModel;
using Final_Project.Views.Pages.UserPanelPages;
using Final_Project.Views.Windows;

namespace Final_Project.ViewModels.WindowsViewModel
{
    public class ResturantWindowViewModel : ViewModelBase
    {
        public static Resturant MainResturant;
        public Order MainOrder;



        private string _ResturantNameField;

        public string ResturantNameField
        {
            get { return _ResturantNameField ; }
            set { _ResturantNameField = value; OnPropertyChanged(); }
        }

        private string _HintField;

        public string HintField
        {
            get { return _HintField; }
            set { _HintField = value; OnPropertyChanged(); }
        }



        private ObservableCollection<UserControl> _ItemSourceField = new ObservableCollection<UserControl>();
        public ObservableCollection<UserControl> ItemSourceField
        {
            get { return _ItemSourceField; }
            set { _ItemSourceField = value; }
        }



        public ResturantWindowViewModel(Resturant mainResturant) 
        {
            MainResturant = mainResturant;
            ResturantNameField = MainResturant.Name;
            BuildCollection(MainResturant.Foods);
        }


        public RelayCommand OrderBTNCommand => new RelayCommand(execute => BiuldOrder());

        public RelayCommand ReserveBTNCommand => new RelayCommand(execute =>
        {
            ReserveBox rb = new ReserveBox(MainResturant);
            ReserveBoxViewModel rbVM = new ReserveBoxViewModel(MainResturant, rb);
            bool isAllOk = true;
            if(!MainResturant.ActiveReserve)
            {
                isAllOk = false;
                HintField = "Reservation is not Active for this Resturant";
                return;
            }
            if(!UserPanelViewModel.MainCustomer.CanReserve())
            {
                isAllOk = false;
                HintField = "you are not able to reserve";
                return;
            }
            if(isAllOk)
            {
                HintField = "";
                rb.ShowDialog();
            }
        });

        private void BiuldOrder ()
        {
            List<Food> orderFoods = new List<Food>();
            foreach(FoodItemViewModel foodContext in ItemSourceField.Select(i => i.DataContext))
            {
                for (int i = 0; i < foodContext.FoodCountField; i++)
                {
                    orderFoods.Add(foodContext.MainFood);
                }
            }
            OrderBox ob = new OrderBox(orderFoods);
            ob.ShowDialog();
        }

        private void BuildCollection(List<Food> foods)
        {
            ItemSourceField.Clear();
            foreach (Food food in foods)
            {
                FoodItemUserControl foodItem = new FoodItemUserControl(food);
                FoodItemViewModel foodItemViewModel = new FoodItemViewModel(food);
                foodItem.DataContext = foodItemViewModel;
                ItemSourceField.Add(foodItem);
            }
        }


    }
}
