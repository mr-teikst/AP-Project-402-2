using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;

namespace Final_Project.ViewModels.UserControlsViewModel
{
    public class FoodItemViewModel : ViewModelBase
    {
        public Food MainFood;

        private string _FoodNameField;

        public string FoodNameField
        {
            get { return _FoodNameField; }
            set { _FoodNameField = value; OnPropertyChanged(); }
        }

        private string _FoodRateField;
        public string FoodRateField
        {
            get { return _FoodRateField; }
            set { _FoodRateField = value; OnPropertyChanged(); }
        }

        private string _FoodDescriptionField;
        public string FoodDescriptionField
        {
            get { return _FoodDescriptionField; }
            set { _FoodDescriptionField = value; OnPropertyChanged(); }
        }
        private string _FoodImageField;
        public string FoodImageField
        {
            get { return _FoodImageField; }
            set { _FoodImageField = value; OnPropertyChanged(); }
        }

        private string _FoodCountField;
        public int FoodCountField
        {
            get { return int.Parse(_FoodCountField); }
            set 
            { 
                _FoodCountField = value.ToString();
                OnPropertyChanged(); 
            }
        }



        public FoodItemViewModel (Food MainFood)
        {
            this.MainFood = MainFood;
            FoodNameField = MainFood.Name;
            FoodRateField = MainFood.Rating.ToString();
            FoodDescriptionField = MainFood.Material;
            FoodImageField = MainFood.Image;
            FoodCountField = 0;
        }

        public RelayCommand PlusBTNCommand => new RelayCommand(execute =>{
            if (FoodCountField < MainFood.Count) FoodCountField++;
        });
        public RelayCommand MinesBTNCommand => new RelayCommand(execute => {
            if (FoodCountField > 0) FoodCountField--;
        });


    }
}
