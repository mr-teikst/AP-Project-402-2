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

		private string _AddressField;

		public string AddressField
		{
			get { return _AddressField; }
			set { _AddressField = value; OnPropertyChanged(); }
		}

		private string _ReservationStatusField;

		public string ReservationStatusField
        {
			get { return _ReservationStatusField; }
			set { _ReservationStatusField = value; OnPropertyChanged(); }
		}


		private string _RateField;

		public string RateField
        {
			get { return _RateField; }
			set { _RateField = value; OnPropertyChanged(); }
		}



	}
}
