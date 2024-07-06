using Final_Project.MVVM;
using Final_Project.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Final_Project.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
		public MainWindowViewModel() 
		{
			MainFrameField = new Login(this);
        }
		private Page _MainFrameField;

		public Page MainFrameField
        {
			get { return _MainFrameField; }
			set { _MainFrameField = value; OnPropertyChanged(); }
		}

	}
}
