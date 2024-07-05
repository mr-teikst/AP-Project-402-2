﻿using Final_Project.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Final_Project.Views.Pages.UserPanelPages;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class UserPanelViewModel : ViewModelBase
    {
		private UserPanelProfile _UserPanelFrame = new UserPanelProfile();

		public UserPanelProfile UserPanelFrame
        {
			get { return _UserPanelFrame; }
			set 
			{
				_UserPanelFrame = value;
				OnPropertyChanged();
			}
		}


    }
}
