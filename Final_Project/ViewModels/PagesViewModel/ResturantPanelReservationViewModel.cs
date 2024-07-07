using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.MVVM;
using Final_Project.Views.Pages.ResturantPanelPages;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class ResturantPanelReservationViewModel : ViewModelBase
    {
        private string _NameBTNField;

        public string NameBTNField
        {
            get { return _NameBTNField; }
            set { _NameBTNField = value; OnPropertyChanged(); }
        }

        private bool _IsEnableField;

        public bool IsEnableField
        {
            get { return _IsEnableField; }
            set { _IsEnableField = value; OnPropertyChanged(); }
        }

        private bool _StateField = false;

        public string StateField 
        {
            get { return _StateField == true ? "Enable" : "Unable"; }
            set { _StateField = value == "Enable"? true : false; OnPropertyChanged(); }
        }

        private string _HintField;

        public string HintField
        {
            get { return _HintField; }
            set { _HintField = value; OnPropertyChanged(); }
        }

        public ResturantPanelReservationViewModel()
        {
            ResturantPanelViewModel.MainResturant.CheckReserveState();
            if (!IsEnableField) HintField = "you do not have enough rate";
            else HintField = "";
            IsEnableField = _StateField ? true : ResturantPanelViewModel.MainResturant.CanReserve;
            NameBTNField = StateField == "Enable" ? "Unable Reservation" : "Enable Reservation";

        }

        public RelayCommand EnableBTNCommand => new RelayCommand(execute =>
        {
            IsEnableField = _StateField ? true : ResturantPanelViewModel.MainResturant.CanReserve;
            StateField = StateField == "Enable" ? "Unable" : "Enable";
            NameBTNField = StateField == "Enable" ? "Unable Reservation" : "Enable Reservation";
            ResturantPanelViewModel.MainResturant.ChangeReserveState();
        });
    }
}
