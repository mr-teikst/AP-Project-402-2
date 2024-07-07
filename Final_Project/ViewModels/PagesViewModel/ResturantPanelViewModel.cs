using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ApProject.Models;
using Final_Project.MVVM;
using Final_Project.Views.Pages.ResturantPanelPages;

namespace Final_Project.ViewModels.PagesViewModel
{
    internal class ResturantPanelViewModel : ViewModelBase
    {
        static public Resturant MainResturant { get; set; }


        private Page _ResturantPanelFrame;

		public Page ResturantPanelFrame
        {
			get { return _ResturantPanelFrame; }
			set { _ResturantPanelFrame = value;OnPropertyChanged(); }
		}

		public ResturantPanelViewModel(Resturant mainResturant)
		{
			MainResturant = mainResturant;
            ResturantPanelFrame = new ResturantPanelChangeMenu();

        }

        public RelayCommand ChangeMenuBTNCommand => new RelayCommand(execute => ResturantPanelFrame = new ResturantPanelChangeMenu());
        public RelayCommand ReservationBTNCommand => new RelayCommand(execute => ResturantPanelFrame = new ResturantPanelReservation());
        //public RelayCommand HistoryBTNCommand => new RelayCommand(execute => ResturantPanelFrame = new Res());


    }
}
