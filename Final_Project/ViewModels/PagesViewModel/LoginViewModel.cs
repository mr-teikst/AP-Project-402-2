using Final_Project.MVVM;
using Final_Project.ViewModels.UserControlsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.Views.Pages.UserPanelPages;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class LoginViewModel : ViewModelBase
    {
        public TextInputViewModel UserNameCVVM { get; set; }
        public TextInputViewModel PasswordCVVM { get; set; }
        private MainWindowViewModel mw;

        public LoginViewModel(MainWindowViewModel mw)
        {
            this.mw = mw;
            UserNameCVVM = new TextInputViewModel() { NameField = "User Name" };
            PasswordCVVM = new TextInputViewModel() { NameField = "Password" };
            Customer u = new Customer("erfan", "123", "erfan", "teikst", "09336632932", new System.Net.Mail.MailAddress("erfan.teikst2027@gmail.com"), "", Gender.Male);
        }


        public RelayCommand LoginCommand => new RelayCommand(execute => LoginFunc(UserNameCVVM.TextField, PasswordCVVM.TextField));


        private void LoginFunc(string username, string password)
        {
            User result = User.Login(username, password);
            if (result == null)
            {
                UserNameCVVM.HintField = "Wrong username or password";
            }
            else
            {
                UserNameCVVM.HintField = "loged in successfully";
                if(result is Customer)
                {
                    mw.MainFrameField = new  UserPanel();
                }
            }
        }


    }
}
