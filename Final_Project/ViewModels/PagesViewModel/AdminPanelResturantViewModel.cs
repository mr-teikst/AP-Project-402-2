using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;

namespace Final_Project.ViewModels.PagesViewModel
{
    class AdminPanelResturantViewModel : ViewModelBase
    {

        private string _HintField;

        public string HintField
        {
            get { return _HintField; }
            set { _HintField = value; OnPropertyChanged(); }
        }

        private string _UserNameField;

        public string UserNameField
        {
            get { return _UserNameField; }
            set { _UserNameField = value; OnPropertyChanged(); }
        }

        private string _NameField;

        public string NameField
        {
            get { return _NameField; }
            set { _NameField = value; OnPropertyChanged(); }
        }
        private string _CityField;

        public string CityField
        {
            get { return _CityField; }
            set { _CityField = value; OnPropertyChanged(); }
        }

        private string _AddressField;

        public string AddressField
        {
            get { return _AddressField; }
            set { _AddressField = value; OnPropertyChanged(); }
        }


        private string _PassWordField;

        public string PassWordField
        {
            get { return _PassWordField; }
            set { _PassWordField = value; OnPropertyChanged(); }
        }


        public RelayCommand MakeBTNCommand => new RelayCommand(execute =>
        {
            bool isAllOk = true;
            if (UserNameField == null || !Resturant.ValidateUsername(UserNameField))
            {
                isAllOk = false;
                HintField = "Invalid UserName";
                return;
            }
            if (NameField == null || !Customer.ValidateName(NameField))
            {
                isAllOk = false;
                HintField = "Invalid Name";
                return;
            }
            if (CityField == null || !Customer.ValidateName(CityField))
            {
                isAllOk = false;
                HintField = "Invalid City";
                return;
            }
            if(AddressField == null)
            {
                isAllOk = false;
                HintField = "Invalid Address";
                return;
            }

            if(isAllOk)
            {
                string pass = Resturant.GenerateRandomPassword();
                Resturant r = new Resturant(UserNameField, pass, NameField, CityField, AddressField);
                PassWordField = pass;
            }
            
        });
    }
}
