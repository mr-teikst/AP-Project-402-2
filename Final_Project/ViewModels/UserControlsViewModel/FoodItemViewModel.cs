using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.ViewModels.WindowsViewModel;
using Final_Project.Views.Windows;
using Final_Project.ViewModels.PagesViewModel;
using System.Windows;

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


        public RelayCommand CommentBTNCommand => new RelayCommand(execute =>
        {
            InputPopUp pw = new InputPopUp();
            InputPopUpViewModel pwVM = new InputPopUpViewModel(pw);
            pw.DataContext = pwVM;
            string? result = null;
            pwVM.OkTask = (VM) =>
            {
                if(VM.TextField != null)
                {
                    VM.Result = VM.TextField;
                    VM.mw.Close();
                }
                else
                {
                    VM.HintField = "Comment Field could not be empty";
                    VM.Result = null;
                }
            };
            pw.ShowDialog();
            result = pwVM.Result;
            if (result != null )
            {
                MainFood.AddComment(UserPanelViewModel.MainCustomer, result);
            }
            
        });

        public RelayCommand RateBTNCommand => new RelayCommand(execute =>
        {
            InputPopUp pw = new InputPopUp();
            InputPopUpViewModel pwVM = new InputPopUpViewModel(pw);
            pw.DataContext = pwVM;
            string? result = null;
            pwVM.OkTask = (VM) =>
            {
                if (VM.TextField != null)
                {
                    try
                    {
                        double v = double.Parse(VM.TextField);
                        if (v < 0 || v > 5) throw new Exception();
                        VM.Result = VM.TextField;
                        VM.mw.Close();
                    }
                    catch
                    {
                        VM.HintField = "Invalid rate (0 <= rate <= 5)";
                        VM.Result = null;
                    }
                    
                }
                else
                {
                    VM.HintField = "Rate Field could not be empty";
                    VM.Result = null;
                }
            };
            pw.ShowDialog();
            result = pwVM.Result;
            if (result != null)
            {
                MainFood.AddRate(UserPanelViewModel.MainCustomer, double.Parse(result));
            }

        });


    }
}
