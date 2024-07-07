using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.ViewModels.UserControlsViewModel;
using Final_Project.Views.UserControls;

namespace Final_Project.ViewModels.PagesViewModel
{
    class UserPanelHistoryViewModel : ViewModelBase
    {

        private ObservableCollection<Order> _ItemSourceField = new ObservableCollection<Order>();
        public ObservableCollection<Order> ItemSourceField
        {
            get { return _ItemSourceField; }
            set { _ItemSourceField = value; }
        }

        public UserPanelHistoryViewModel()
        {
            BuildCollection(UserPanelViewModel.MainCustomer.Orders);
        }

        private Order _SelectedItemField;

        public Order SelectedItemField
        {
            get { return _SelectedItemField; }
            set { _SelectedItemField = value; OnPropertyChanged(); }
        }

        private string _CommentField;

        public string CommentField
        {
            get { return _CommentField; }
            set { _CommentField = value; OnPropertyChanged(); }
        }

        private string _RateField;

        public double RateField
        {
            get 
            {
                try
                {
                    double t = double.Parse(_RateField);
                    if (t < 0 || t > 5) throw new Exception();
                    return t;
                }
                catch
                {
                    return -1;
                }
                
            }
            set { _RateField = value.ToString(); OnPropertyChanged(); }
        }
        private string _PriceField;

        public double PriceField
        {
            get
            {
                try
                {
                    return double.Parse(_PriceField);
                }
                catch
                {
                    return 0;
                }
            }
            set { _PriceField = value.ToString(); OnPropertyChanged(); }
        }

        public RelayCommand AddCommentBTNCommand => new RelayCommand(execute => 
        { 
            if (SelectedItemField != null && CommentField != null)
            {
                Order order = SelectedItemField as Order;
                order.AddComment(CommentField);
            }
            BuildCollection(UserPanelViewModel.MainCustomer.Orders);
        });

        public RelayCommand AddRateBTNCommand => new RelayCommand(execute =>
        {
            if (SelectedItemField != null && RateField != null && RateField != -1)
            {
                Order order = SelectedItemField as Order;
                order.AddRating(RateField);
            }
            BuildCollection(UserPanelViewModel.MainCustomer.Orders);
        });

        private void BuildCollection(List<Order> orders)
        {
            ItemSourceField.Clear();
            foreach (Order order in orders)
            {
                ItemSourceField.Add(order);
            }
        }
    }
}
