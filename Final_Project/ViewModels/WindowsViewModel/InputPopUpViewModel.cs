using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Final_Project.MVVM;

namespace Final_Project.ViewModels.WindowsViewModel
{
    internal class InputPopUpViewModel : ViewModelBase
    {
        public Window mw;


        private string _TextField;

        public string TextField
        {
            get { return _TextField; }
            set { _TextField = value; OnPropertyChanged(); }
        }
        private string _HintField;

        public string HintField
        {
            get { return _HintField; }
            set { _HintField = value; OnPropertyChanged(); }
        }
        private string? _Result;

        public string? Result
        {
            get { return _Result; }
            set { _Result = value; OnPropertyChanged(); }
        }

        private Action<InputPopUpViewModel> _OkTask;

        public Action<InputPopUpViewModel> OkTask
        {
            get { return _OkTask; }
            set { _OkTask = value; OnPropertyChanged(); }
        }


        public InputPopUpViewModel(Window mw)
        {
            this.mw = mw;
        }

        public RelayCommand OKBTNCommand => new RelayCommand(execute =>
        {
            OkTask(this);
        });
    }
}
