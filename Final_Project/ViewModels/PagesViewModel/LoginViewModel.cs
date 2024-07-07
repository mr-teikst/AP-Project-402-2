using Final_Project.MVVM;
using Final_Project.ViewModels.UserControlsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.Views.Pages.UserPanelPages;
using Final_Project.Views.Pages;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        public TextInputViewModel UserNameUCVM { get; set; }
        public TextInputViewModel PasswordUCVM { get; set; }
        private MainWindowViewModel mw;

        public LoginViewModel(MainWindowViewModel mw)
        {
            this.mw = mw;
            UserNameUCVM = new TextInputViewModel() { NameField = "User Name" };
            PasswordUCVM = new TextInputViewModel() { NameField = "Password" };
            Customer u = new Customer("erfan", "123", "erfan", "teikst", "09336632932", new System.Net.Mail.MailAddress("erfan.teikst2027@gmail.com"), "", Gender.Male);
        }


        public RelayCommand LoginCommand => new RelayCommand(execute => LoginFunc(UserNameUCVM.TextField, PasswordUCVM.TextField));
        public RelayCommand SignUpCommand => new RelayCommand(execute => SignUpFunc());

        private void LoginFunc(string username, string password)
        {
            User result = User.Login(username, password);
            if (result == null)
            {
                UserNameUCVM.HintField = "Wrong username or password";
            }
            else
            {
                PasswordUCVM.HintField = "loged in successfully";
                if(result is Customer)
                {
                    mw.MainFrameField = new UserPanel(result as Customer);
                }
            }
        }

        private void SignUpFunc()
        {
            mw.MainFrameField = new SignUp(mw);
        }


    }
}
