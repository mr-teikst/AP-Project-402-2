using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.MVVM;

namespace Final_Project.ViewModels.UserControlsViewModel
{
    internal class ResturantSearchItemViewModel : ViewModelBase
    {
		private string _ResturantNameField;

		public string ResturantNameField
        {
			get { return _ResturantNameField; }
			set { _ResturantNameField = value; OnPropertyChanged();  }
		}

	}
}
