using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Final_Project.MVVM;
using Final_Project.Views.Pages.ResturantPanelPages;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class ResturantPanelViewModel : ViewModelBase
    {
		private Page _ResturantPanelFrame = new ResturantPanelReservation();

		public Page ResturantPanelFrame
        {
			get { return _ResturantPanelFrame; }
			set 
			{
				_ResturantPanelFrame = value;
				OnPropertyChanged();
			}
		}

	}
}
