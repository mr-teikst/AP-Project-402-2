using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.ViewModels.PagesViewModel;
using Final_Project.ViewModels.WindowsViewModel;
using Final_Project.Views.Windows;
using static Final_Project.ViewModels.WindowsViewModel.ShowCommandPopUpViewModel;

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

        public RelayCommand ShowCommentBTNCommand => new RelayCommand(execute =>
        {
            AnswerCommentPopUp pw = new AnswerCommentPopUp(MainFood);
            AnswerCommentPopUpViewModel pwVM = new AnswerCommentPopUpViewModel(MainFood);
            pw.DataContext = pwVM;
            pw.Show();
        });
    }
}
