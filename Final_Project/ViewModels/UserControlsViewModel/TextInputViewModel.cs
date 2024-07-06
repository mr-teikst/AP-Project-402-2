using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Final_Project.MVVM;

namespace Final_Project.ViewModels.UserControlsViewModel
{
    internal class TextInputViewModel : ViewModelBase
    {
        private string? _NameField;
        public string? NameField
        {
            get { return _NameField; }
            set
            {
                _NameField = value;
                OnPropertyChanged();
            }
        }

        private string? _HintField;
        public string? HintField
        {
            get { return _HintField; }
            set
            {
                _HintField = value;
                OnPropertyChanged();
            }
        }

        private string? _TextField;
        public string? TextField
        {
            get 
            {
                if (_TextField == null) return "";
                else return _TextField;
            }
            set
            {
                _TextField = value;
                OnPropertyChanged();
            }
        }

        private bool _EnabilityField = true;
        public bool EnabilityField
        {
            get { return _EnabilityField; }
            set
            {
                _EnabilityField = value;
                OnPropertyChanged();
            }
        }



    }
}
