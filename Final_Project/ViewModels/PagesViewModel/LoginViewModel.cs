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
using Final_Project.Views.Pages.ResturantPanelPages;
using System.Security.Cryptography;

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
            Resturant r = new Resturant("res", "res", "res3", "tehran", "tehran markaz");
            r.Foods.Add(Food.f1);
            r.Foods.Add(Food.f2);
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
                else if(result is Resturant)
                {
                    mw.MainFrameField = new ResturantPanel(result as Resturant);
                }
            }
        }

        private void SignUpFunc()
        {
            mw.MainFrameField = new SignUp(mw);
        }


    }
}
