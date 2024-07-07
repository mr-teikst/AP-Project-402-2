using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.MVVM;
using Final_Project.Views.Windows;
using Microsoft.Win32;

namespace Final_Project.ViewModels.WindowsViewModel
{
    internal class AddNewFoodPopUpViewModel : ViewModelBase
    {
        private string _NameField;

        public string NameField
        {
            get { return _NameField; }
            set { _NameField = value; OnPropertyChanged(); }
        }

        private string _MaterialField;

        public string MaterialField
        {
            get { return _MaterialField; }
            set { _MaterialField = value; OnPropertyChanged(); }
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

        private string _CountField;

        public int CountField
        {
            get
            {
                try
                {
                    return int.Parse(_CountField);
                }
                catch
                {
                    return 0;
                }
            }
            set { _CountField = value.ToString(); OnPropertyChanged(); }
        }

        private string _HintField;

        public string HintField
        {
            get { return _HintField; }
            set { _HintField = value; OnPropertyChanged(); }
        }

        private string _ImageFileField;

        public string ImageFileField
        {
            get { return _ImageFileField; }
            set { _ImageFileField = value; OnPropertyChanged(); }
        }

        public AddNewFoodPopUp mw;

        public AddNewFoodPopUpViewModel (AddNewFoodPopUp mw)
        {
            this.mw = mw;
        }

        public RelayCommand ImageFileBTNCommand => new RelayCommand(execute =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                ImageFileField = filePath;
            }

        });

        private Action _OkTask;

        public Action OkTask
        {
            get { return _OkTask; }
            set { _OkTask = value; OnPropertyChanged(); }
        }

        public RelayCommand OkBTNCommand => new RelayCommand(execute =>  OkTask() );

    }
}
