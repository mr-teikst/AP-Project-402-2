using Final_Project.MVVM;
using Final_Project.ViewModels.UserControlsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using System.Net.Mail;
using Final_Project.Views.Pages.UserPanelPages;
using Final_Project.Views.Pages;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class SignUpViewModel : ViewModelBase
    {
        public TextInputViewModel NameFieldUCVM { get; set; }
        public TextInputViewModel LastNameFieldUCVM { get; set; }
        public TextInputViewModel UserNameFieldUCVM { get; set; }
        public TextInputViewModel EmailFieldUCVM { get; set; }
        public TextInputViewModel MobileFieldUCVM { get; set; }
        public TextInputViewModel PasswordFieldUCVM { get; set; }
        public TextInputViewModel ConfirmPasswordFieldUCVM { get; set; }
        public TextInputViewModel CodeFieldUCVM { get; set; }

        private bool _CodeBTN_EN = true;

        public bool CodeBTN_EN
        {
            get { return _CodeBTN_EN; }
            set { _CodeBTN_EN = value; OnPropertyChanged(); }
        }

        private bool _CodeCheckBTN_EN;

        public bool CodeCheckBTN_EN
        {
            get { return _CodeCheckBTN_EN; }
            set { _CodeCheckBTN_EN = value; OnPropertyChanged(); }
        }

        private bool _SignUpBTN_EN = false;

        public bool SignUpBTN_EN
        {
            get { return _SignUpBTN_EN; }
            set { _SignUpBTN_EN = value; OnPropertyChanged(); }
        }




        private MainWindowViewModel mw;

        public SignUpViewModel(MainWindowViewModel mw)
        {
            this.mw = mw;
            NameFieldUCVM = new TextInputViewModel() { NameField = "Name" };
            LastNameFieldUCVM = new TextInputViewModel() { NameField = "Last Name" };
            UserNameFieldUCVM = new TextInputViewModel() { NameField = "User Name" };
            EmailFieldUCVM = new TextInputViewModel() { NameField = "Email" };
            MobileFieldUCVM = new TextInputViewModel() { NameField = "Mobile" };
            CodeFieldUCVM = new TextInputViewModel() { NameField = "Code" };
            PasswordFieldUCVM = new TextInputViewModel() { NameField = "Password" , EnabilityField = false};
            ConfirmPasswordFieldUCVM = new TextInputViewModel() { NameField = "Confirm Password", EnabilityField = false};

        }



        public RelayCommand CodeBTNCommand => new RelayCommand(execute => SendCode());
        public RelayCommand CodeCheckBTNCommand => new RelayCommand(execute => CheckCode());
        public RelayCommand SignUpBTNCommand => new RelayCommand(execute => SignUpFunc());
        public RelayCommand LoginBTNCommand => new RelayCommand(execute => LoginFunc());


        private string _Code;
        private void SendCode()
        {
            bool isAllOk = true;
            if(!Customer.ValidateName(NameFieldUCVM.TextField))
            {
                isAllOk = false;
                NameFieldUCVM.HintField = "Invalid name";
            }
            else NameFieldUCVM.HintField = "";

            if (!Customer.ValidateName(LastNameFieldUCVM.TextField))
            {
                isAllOk = false;
                LastNameFieldUCVM.HintField = "Invalid last name";
            }
            else LastNameFieldUCVM.HintField = "";

            if (!Customer.ValidateUsername(UserNameFieldUCVM.TextField))
            {
                isAllOk = false;
                UserNameFieldUCVM.HintField = "Invalid user name";
            }
            else UserNameFieldUCVM.HintField = "";

            if (!Customer.ValidateMobile(MobileFieldUCVM.TextField))
            {
                isAllOk = false;
                MobileFieldUCVM.HintField = "Invalid mobile";
            }
            else MobileFieldUCVM.HintField = "";

            if (!Customer.ValidateEmail(EmailFieldUCVM.TextField))
            {
                isAllOk = false;
                EmailFieldUCVM.HintField = "Invalid email";
            }
            else EmailFieldUCVM.HintField = "";

            if (isAllOk)
            {
                _Code = Customer.GenerateAndSendVerificationCode(EmailFieldUCVM.TextField);
                CodeCheckBTN_EN = true;
            }
        }


        private void CheckCode()
        {
            if(CodeFieldUCVM.TextField == _Code)
            {
                CodeFieldUCVM.HintField = "Code valided";
                PasswordFieldUCVM.EnabilityField = true;
                ConfirmPasswordFieldUCVM.EnabilityField = true;
                SignUpBTN_EN = true ;

            }
            else
            {
                CodeFieldUCVM.HintField = "Invalid Code";
                PasswordFieldUCVM.EnabilityField = false;
                ConfirmPasswordFieldUCVM.EnabilityField = false;
                SignUpBTN_EN = false;
            }
        }

        private void SignUpFunc()
        {
            bool isAllOk = true;
            if (!Customer.ValidatePassword(PasswordFieldUCVM.TextField))
            {
                isAllOk = false;
                PasswordFieldUCVM.HintField = "Invalid Password";
            }
            else PasswordFieldUCVM.HintField = "";

            if (PasswordFieldUCVM.TextField != ConfirmPasswordFieldUCVM.TextField)
            {
                isAllOk = false;
                ConfirmPasswordFieldUCVM.HintField = "Not match";
            }
            else ConfirmPasswordFieldUCVM.HintField = "";
            
            if(isAllOk)
            {
                Customer customer = new Customer(UserNameFieldUCVM.TextField,
                                                 PasswordFieldUCVM.TextField,
                                                 NameFieldUCVM.TextField,
                                                 LastNameFieldUCVM.TextField,
                                                 MobileFieldUCVM.TextField,
                                                 new MailAddress(EmailFieldUCVM.TextField),
                                                 "",
                                                 Gender.None);
                mw.MainFrameField = new UserPanel(customer);
            }

        }

        private void LoginFunc()
        {
            mw.MainFrameField = new Login(mw);
        }


    }

    
}
