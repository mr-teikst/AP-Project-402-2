using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;

namespace Final_Project.ViewModels.UserControlsViewModel
{
    internal class OrderItemViewModel : ViewModelBase
    {
        public Food MainFood;

        private string _FoodNameField;

        public string FoodNameField
        {
            get { return _FoodNameField; }
            set { _FoodNameField = value; OnPropertyChanged(); }
        }

        private string _FoodPriceField;

        public string FoodPriceField
        {
            get { return _FoodPriceField; }
            set { _FoodPriceField = value; OnPropertyChanged(); }
        }

        private string _FoodCountField;

        public string FoodCountField
        {
            get { return _FoodCountField; }
            set { _FoodCountField = value; OnPropertyChanged(); }
        }


        public OrderItemViewModel(Food food, int foodCount) 
        { 
            MainFood = food;
            FoodNameField = MainFood.Name;
            FoodPriceField = MainFood.Price.ToString() + "$";
            FoodCountField = foodCount.ToString();
        }
    }
}
