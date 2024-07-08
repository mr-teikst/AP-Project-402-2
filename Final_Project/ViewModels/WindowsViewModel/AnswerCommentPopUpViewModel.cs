using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.ViewModels.PagesViewModel;
using static Final_Project.ViewModels.WindowsViewModel.ShowCommandPopUpViewModel;

namespace Final_Project.ViewModels.WindowsViewModel
{
    class AnswerCommentPopUpViewModel : ViewModelBase
    {

        public Food MainFood;

        public AnswerCommentPopUpViewModel(Food mainFood)
        {
            MainFood = mainFood;
            BuildCollection(MainFood.Comments);
        }



        private ObservableCollection<Comment> _ItemSourceField = new ObservableCollection<Comment>();
        public ObservableCollection<Comment> ItemSourceField
        {
            get { return _ItemSourceField; }
            set { _ItemSourceField = value; }
        }

        private Comment _SelectedItemField;

        public Comment SelectedItemField
        {
            get { return _SelectedItemField; }
            set { _SelectedItemField = value; OnPropertyChanged(); }
        }


        private string _AnswerField;

        public string AnswerField
        {
            get { return _AnswerField; }
            set { _AnswerField = value; OnPropertyChanged(); }
        }


        private string _HintField;

        public string HintField
        {
            get { return _HintField; }
            set { _HintField = value; OnPropertyChanged(); }
        }



        public RelayCommand AnswerBTNCommand => new RelayCommand(execute =>
        {
            bool isAllOk = true;
            if (SelectedItemField == null)
            {
                HintField = "please select item first";
                isAllOk = false;
                return;
            }
            if (AnswerField == null)
            {
                HintField = "Answer could not be empty";
                isAllOk = false;
                return;
            }
            if (isAllOk)
            {
                Comment comment = SelectedItemField as Comment;
                comment.Respond(AnswerField);
                BuildCollection(MainFood.Comments);
            }
        });


        private void BuildCollection(List<Comment> Comments)
        {
            ItemSourceField.Clear();
            foreach (Comment comment in Comments)
            {
                ItemSourceField.Add(comment);
            }
        }
    }
}
