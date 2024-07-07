using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.ViewModels.UserControlsViewModel;
using Final_Project.ViewModels.WindowsViewModel;
using Final_Project.Views.UserControls;
using Final_Project.Views.Windows;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class ResturantPanelChangeMenuViewModel : ViewModelBase
    {

        private ObservableCollection<FoodMenuItemUserControl> _ItemSourceField = new ObservableCollection<FoodMenuItemUserControl>();
        public ObservableCollection<FoodMenuItemUserControl> ItemSourceField
        {
            get { return _ItemSourceField; }
            set { _ItemSourceField = value; }
        }


        private FoodMenuItemUserControl _SelectedItemField;

        public FoodMenuItemUserControl SelectedItemField
        {
            get { return _SelectedItemField; }
            set { _SelectedItemField = value; }
        }


        public ResturantPanelChangeMenuViewModel() 
        {
            BuildCollection(ResturantPanelViewModel.MainResturant.Foods);
        }


        public RelayCommand AddNewFoodBTNCommand => new RelayCommand(execute =>
        {
            AddNewFoodPopUp pw = new AddNewFoodPopUp();
            AddNewFoodPopUpViewModel pwVM = new AddNewFoodPopUpViewModel(pw);
            pw.DataContext = pwVM;
            pwVM.OkTask = () =>
            {
                if(pwVM.NameField == null)
                {
                    pwVM.HintField = "Name could not be empty";
                    return;
                }
                if(pwVM.MaterialField == null)
                {
                    pwVM.HintField = "Material could not be empty";
                    return;
                }
                if(pwVM.PriceField == null || !Food.ValidatePrice(pwVM.PriceField))
                {
                    pwVM.HintField = "Invalid Price";
                    return;
                }
                if (pwVM.CountField == null || pwVM.CountField <= 0)
                {
                    pwVM.HintField = "Invalid Count";
                    return;
                }
                if (pwVM.ImageFileField == null)
                {
                    pwVM.HintField = "Invalid Image File";
                    return;
                }
                ResturantPanelViewModel.MainResturant.AddFood(pwVM.NameField, pwVM.MaterialField, pwVM.PriceField, pwVM.ImageFileField, pwVM.CountField);
                BuildCollection(ResturantPanelViewModel.MainResturant.Foods);
                pw.Close();
            };
            pw.ShowDialog();
        });


        public RelayCommand DeleteFoodBTNCommand => new RelayCommand(execute =>
        {
            FoodMenuItemViewModel? FoodMenuItemVM;
            try
            {
                FoodMenuItemVM = SelectedItemField.DataContext as FoodMenuItemViewModel;
                if (FoodMenuItemVM == null) return;
            }
            catch
            {
                return;
            }
            ResturantPanelViewModel.MainResturant.Foods.Remove(FoodMenuItemVM.MainFood);
            BuildCollection(ResturantPanelViewModel.MainResturant.Foods);
        });


        public RelayCommand EditFoodBTNCommand => new RelayCommand(execute =>
        {
            Food food;
            try
            {
                FoodMenuItemViewModel? FoodMenuItemVM = SelectedItemField.DataContext as FoodMenuItemViewModel;
                if (FoodMenuItemVM == null) return;
                food = FoodMenuItemVM.MainFood;
            }
            catch
            {
                return;
            }
            AddNewFoodPopUp pw = new AddNewFoodPopUp();
            AddNewFoodPopUpViewModel pwVM = new AddNewFoodPopUpViewModel(pw);
            pw.DataContext = pwVM;

            pwVM.NameField = food.Name;
            pwVM.MaterialField = food.Material;
            pwVM.PriceField = food.Price;
            pwVM.CountField = food.Count;
            pwVM.ImageFileField = food.Image;

            pwVM.OkTask = () =>
            {
                string errormsg = "";
                if (pwVM.NameField != null)
                {
                    food.ChangeName(pwVM.NameField);
                }
                if (pwVM.MaterialField != null)
                {
                    food.ChangeMaterial(pwVM.MaterialField);
                }
                if (pwVM.PriceField != null && Food.ValidatePrice(pwVM.PriceField))
                {
                    food.ChangePrice(pwVM.PriceField);
                }
                else if(pwVM.PriceField != null)
                {
                    errormsg += "Invalid Price ,";
                }
                if (pwVM.CountField != null && pwVM.CountField > 0)
                {
                    food.ChangeCount(pwVM.CountField);
                }
                else if(pwVM.CountField != null)
                {
                    errormsg += "Invalid Count ";
                }
                if (pwVM.ImageFileField != null)
                {
                    food.ChangeImage(pwVM.ImageFileField);
                }
                pwVM.HintField = errormsg;
                BuildCollection(ResturantPanelViewModel.MainResturant.Foods);
                pw.Close();
            };
            pw.ShowDialog();
        });

        private void BuildCollection(List<Food> foods)
        {
            ItemSourceField.Clear();
            foreach (Food food in foods)
            {
                FoodMenuItemUserControl resturantItem = new FoodMenuItemUserControl(food);
                FoodMenuItemViewModel resturantSearchItemViewModel = new FoodMenuItemViewModel(food);
                resturantItem.DataContext = resturantSearchItemViewModel;
                ItemSourceField.Add(resturantItem);
            }
        }
    }
}
