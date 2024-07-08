using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Final_Project.MVVM;
using ApProject.Models;
using Final_Project.ViewModels.UserControlsViewModel;
using Final_Project.Views.UserControls;
using Final_Project.ViewModels.PagesViewModel;

namespace Final_Project.ViewModels.WindowsViewModel
{
    internal class ShowCommandPopUpViewModel : ViewModelBase
    {
        public Food MainFood;


        public ShowCommandPopUpViewModel(Food mainFood)
        {
            MainFood = mainFood;
            BuildCollection(MainFood.Comments);
        }

        internal class CommentRate
        {
            public Comment comment {  get; set; }
            public double? rate { get; set; }

            public CommentRate(Comment comment, double? rate)
            {
                this.comment = comment;
                this.rate = rate;
            }
        }


        private ObservableCollection<CommentRate> _ItemSourceField = new ObservableCollection<CommentRate>();
        public ObservableCollection<CommentRate> ItemSourceField
        {
            get { return _ItemSourceField; }
            set { _ItemSourceField = value; }
        }

        private CommentRate _SelectedItemField;

        public CommentRate SelectedItemField
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

        private string _HintField;

        public string HintField
        {
            get { return _HintField; }
            set { _HintField = value; OnPropertyChanged(); }
        }



        public RelayCommand EditCommentBTNCommand => new RelayCommand(execute =>
        {
            bool isAllOk = true;
            if(SelectedItemField == null )
            {
                HintField = "please select item first";
                isAllOk = false;
                return;
            }
            if(SelectedItemField.comment.Customer != UserPanelViewModel.MainCustomer)
            {
                HintField = "Comment is not for you";
                isAllOk = false;
                return;
            }
            if(CommentField == null)
            {
                HintField = "Comment could not be empty";
                isAllOk = false;
                return;
            }
            if(isAllOk)
            {
                CommentRate comment = SelectedItemField as CommentRate;
                comment.comment.Edit(CommentField);
                BuildCollection(MainFood.Comments);
            }
        });

        public RelayCommand EditRateBTNCommand => new RelayCommand(execute =>
        {
            bool isAllOk = true;
            if (SelectedItemField == null)
            {
                HintField = "please select item first";
                isAllOk = false;
                return;
            }
            if (SelectedItemField.comment.Customer != UserPanelViewModel.MainCustomer)
            {
                HintField = "Comment is not for you";
                isAllOk = false;
                return;
            }
            if (RateField == null)
            {
                HintField = "Rate could not be empty";
                isAllOk = false;
                return;
            }
            if(RateField == -1)
            {
                HintField = "Invalid rate number (0 <= rate <= 5)";
                isAllOk = false;
                return;
            }
            if (isAllOk)
            {
                CommentRate comment = SelectedItemField as CommentRate;
                comment.comment.Edit(comment.comment.Text);
                var o = MainFood.Ratings.Where(r => r.Customer == comment.comment.Customer);
                foreach(var r in o)
                {
                    r.Edit(RateField);
                }
                BuildCollection(MainFood.Comments);
            }
        });

        public RelayCommand DeleteCommentBTNCommand => new RelayCommand(execute =>
        {
            bool isAllOk = true;
            if (SelectedItemField == null)
            {
                HintField = "please select item first";
                isAllOk = false;
                return;
            }
            if (SelectedItemField.comment.Customer != UserPanelViewModel.MainCustomer)
            {
                HintField = "Comment is not for you";
                isAllOk = false;
                return;
            }
            if (isAllOk)
            {
                CommentRate comment = SelectedItemField as CommentRate;
                MainFood.Comments.Remove(comment.comment);
                BuildCollection(MainFood.Comments);
            }
        });

        private void BuildCollection(List<Comment> Comments)
        {
            ItemSourceField.Clear();
            foreach (Comment comment in Comments)
            {
                var o = MainFood.Ratings.Where(r => r.Customer == comment.Customer);
                double? r = (o.Count() > 0) ? o.First().Value : null;
                CommentRate cr = new CommentRate(comment, r);
                ItemSourceField.Add(cr);
            }
        }
    }
}
