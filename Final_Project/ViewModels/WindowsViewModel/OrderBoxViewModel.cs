using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.ViewModels.PagesViewModel;
using Final_Project.ViewModels.UserControlsViewModel;
using Final_Project.Views.Pages.UserPanelPages;
using Final_Project.Views.UserControls;
namespace Final_Project.ViewModels.WindowsViewModel
{
    internal class OrderBoxViewModel : ViewModelBase
    {
        public List<Food> Foods;

        private ObservableCollection<UserControl> _ItemSourceField = new ObservableCollection<UserControl>();
        public ObservableCollection<UserControl> ItemSourceField
        {
            get { return _ItemSourceField; }
            set { _ItemSourceField = value; }
        }


        private string _TotalField;

        public string TotalField
        {
            get { return _TotalField; }
            set { _TotalField = value; }
        }

        public Window w;
        public OrderBoxViewModel(List<Food> foods, Window w)
        {
            this.w = w;
            Foods = foods;
            TotalField = "Total:" + Foods.Sum(x => x.Price).ToString() + "$";
            BuildCollection(Foods);
        }


        public RelayCommand PayOnlineBTNCommand => new RelayCommand(execute =>
        {
            Order order = UserPanelViewModel.MainCustomer.AddOrder(Foods, ResturantWindowViewModel.MainResturant, PaymentType.Online);
            Customer.SendOrderConfirmationEmail(UserPanelViewModel.MainCustomer.Mail.ToString(), order);
            w.Close();
        });

        public RelayCommand PayCashBTNCommand => new RelayCommand(execute =>
        {
            Order order = UserPanelViewModel.MainCustomer.AddOrder(Foods, ResturantWindowViewModel.MainResturant, PaymentType.Cash);
            w.Close();
        });

        private void BuildCollection(List<Food> foods)
        {
            ItemSourceField.Clear();
            foreach (var group in foods.GroupBy(x => x.Name))
            {
                OrderItemUserControl foodItem = new OrderItemUserControl(group.First(), group.Count());
                OrderItemViewModel foodItemViewModel = new OrderItemViewModel(group.First(), group.Count());
                foodItem.DataContext = foodItemViewModel;
                ItemSourceField.Add(foodItem);
            }
        }
    }
}
