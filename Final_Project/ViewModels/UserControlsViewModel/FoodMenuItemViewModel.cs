using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;

namespace Final_Project.ViewModels.UserControlsViewModel
{
    internal class FoodMenuItemViewModel : ViewModelBase
    {
        public Food MainFood { get; set; }

        private string _FoodNameField;

        public string FoodNameField
        {
            get { return _FoodNameField; }
            set { _FoodNameField = value; }
        }

        private string _FoodImageField;

        public string FoodImageField
        {
            get { return _FoodImageField; }
            set { _FoodImageField = value; }
        }


        public FoodMenuItemViewModel(Food mainFood) 
        {
            MainFood = mainFood;
            FoodNameField = MainFood.Name;
            FoodImageField = mainFood.Image;
        }
    }
}
