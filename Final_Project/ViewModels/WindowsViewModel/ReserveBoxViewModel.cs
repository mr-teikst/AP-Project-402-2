using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.ViewModels.PagesViewModel;
using Final_Project.Views.Windows;

namespace Final_Project.ViewModels.WindowsViewModel
{
    internal class ReserveBoxViewModel : ViewModelBase
    {

        Resturant MainResturant;
        ReserveBox mw;
        public ReserveBoxViewModel(Resturant mainResturant, ReserveBox mw)
        {
            MainResturant = mainResturant;
            this.mw = mw;
        }

        private DateTime _SelectedDateField = DateTime.Now;

		public DateTime SelectedDateField
        {
			get { return _SelectedDateField; }
			set { _SelectedDateField = value; OnPropertyChanged(); }
		}
        private string _HintField;

        public string HintField
        {
            get { return _HintField; }
            set { _HintField = value; OnPropertyChanged(); }
        }


        private string _PriceField;

        public double PriceField
        {
            get 
            { 
                try
                {
                    double t = double.Parse(_PriceField);
                    if (t <= 0) throw new Exception();
                    return t;
                }
                catch
                {
                    return 0;
                }
                
            }
            set { _PriceField = value.ToString(); OnPropertyChanged(); }
        }

        public RelayCommand OkBTNCommand => new RelayCommand(execute =>
        {
            bool isAllOk = true;
            if(PriceField == null)
            {
                isAllOk = false;
                HintField = "Price could not be empty";
                return;
            }
            if(PriceField == 0)
            {
                isAllOk = false;
                HintField = "invalid Price";
                return;
            }
            if(SelectedDateField == null)
            {
                isAllOk = false;
                HintField = "Date could not be empty";
                return;
            }
            if(SelectedDateField <= DateTime.Now)
            {
                isAllOk = false;
                HintField = "Date should set to future";
                return;
            }
            if(isAllOk)
            {
                Reserve reserve = new Reserve(UserPanelViewModel.MainCustomer, MainResturant, PriceField, SelectedDateField);
            }
            mw.Close();

        });

    }
}
