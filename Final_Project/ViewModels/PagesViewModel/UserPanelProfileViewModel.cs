using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;
using static Final_Project.ViewModels.WindowsViewModel.ShowCommandPopUpViewModel;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class UserPanelProfileViewModel : ViewModelBase
    {

        Customer MainCustomer = UserPanelViewModel.MainCustomer;

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
        private string _LastNameField;

        public string LastNameField
        {
            get { return _LastNameField; }
            set { _LastNameField = value; OnPropertyChanged(); }
        }
        private string _MobileField;

        public string MobileField
        {
            get { return _MobileField; }
            set { _MobileField = value; OnPropertyChanged(); }
        }
        private string _EmailField;

        public string EmailField
        {
            get { return _EmailField; }
            set { _EmailField = value; OnPropertyChanged(); }
        }
        private string _GenderField;

        public string GenderField
        {
            get { return _GenderField; }
            set { _GenderField = value; OnPropertyChanged(); }
        }
        private string _AddressField;

        public string AddressField
        {
            get { return _AddressField; }
            set { _AddressField = value; OnPropertyChanged(); }
        }

        public RelayCommand ApplyBTNCommand => new RelayCommand(execute =>
        {
            if (UserNameField != null && Customer.ValidateUsername(UserNameField))
            {
                HintField = "";
                MainCustomer.UserName = UserNameField;
            }
            else if (UserNameField != null) HintField = "Invalid User Name";

            if (NameField != null && Customer.ValidateName(NameField))
            {
                HintField = "";
                MainCustomer.FirstName = NameField;
            }
            else if(NameField != null) HintField = "Invalid Name";

            if (LastNameField != null && Customer.ValidateName(LastNameField))
            {
                HintField = "";
                MainCustomer.LastName = LastNameField;
            }
            else if (LastNameField != null) HintField = "Invalid LastNameField";

            if (MobileField != null && Customer.ValidateMobile(MobileField))
            {
                HintField = "";
                MainCustomer.PhoneNumebr = MobileField;
            }
            else if (MobileField != null) HintField = "Invalid MobileField";

            if (EmailField != null && Customer.ValidateEmail(EmailField))
            {
                HintField = "";
                MainCustomer.ChangeEmail(EmailField);
            }
            else if (EmailField != null) HintField = "Invalid EmailField";

            if (GenderField != null && GenderField.ToLower() == "male")
            {
                HintField = "";
                MainCustomer.Gender = Gender.Male;
            }
            else if (GenderField != null && GenderField.ToLower() == "female")
            {
                HintField = "";
                MainCustomer.Gender = Gender.Female;
            }
            else if (EmailField != null) HintField = "Invalid GenderField (male|female)";

            if (AddressField != null)
            {
                HintField = "";
                MainCustomer.ChangePostAddress(AddressField);
            }
            else if (AddressField != null) HintField = "Invalid AddressField";
        });


        public RelayCommand BeronzeBTNCommand => new RelayCommand(execute =>
        {
            MainCustomer.Type = ApProject.Models.Type.Bronze;
        });
        public RelayCommand SilverBTNCommand => new RelayCommand(execute =>
        {
            MainCustomer.Type = ApProject.Models.Type.Silver;
        });
        public RelayCommand GoldBTNCommand => new RelayCommand(execute =>
        {
            MainCustomer.Type = ApProject.Models.Type.Golden;
        });

    }
}
