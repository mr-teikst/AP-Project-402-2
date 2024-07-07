using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Final_Project.MVVM;
using ApProject.Models;

namespace Final_Project.ViewModels.WindowsViewModel
{
    internal class ShowCommandPopUpViewModel : ViewModelBase
    {
        public Food MainFood;

        private ObservableCollection<Comment> _ItemSourceField = new ObservableCollection<Comment>();
        public ObservableCollection<Comment> ItemSourceField
        {
            get { return _ItemSourceField; }
            set { _ItemSourceField = value; }
        }

        public ShowCommandPopUpViewModel(Food mainFood) 
        {
            MainFood = mainFood;
            ItemSourceField = new ObservableCollection<Comment>(MainFood.Comments);
        }
    }
}
