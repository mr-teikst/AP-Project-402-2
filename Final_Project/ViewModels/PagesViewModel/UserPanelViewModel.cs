using Final_Project.MVVM;
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
		private Page _UserPanelFrame = new UserPanelSearch();

		public Page UserPanelFrame
        {
			get { return _UserPanelFrame; }
			set 
			{
				_UserPanelFrame = value;
				OnPropertyChanged();
			}
		}


        public RelayCommand ProfileBTNCommand => new RelayCommand(execute => UserPanelFrame = new UserPanelProfile());
        public RelayCommand SearchBTNCommand => new RelayCommand(execute => UserPanelFrame = new UserPanelSearch());
        public RelayCommand HistoryBTNCommand => new RelayCommand(execute => UserPanelFrame = new UserPanelHistory());
        public RelayCommand ComplainBTNCommand => new RelayCommand(execute => UserPanelFrame = new UserPanelComplain());


    }
}
