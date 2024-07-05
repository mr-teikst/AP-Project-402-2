﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Final_Project.ViewModels.PagesViewModel;

namespace Final_Project.Views.Pages.UserPanelPages
{
    /// <summary>
    /// Interaction logic for UserPanelProfile.xaml
    /// </summary>
    public partial class UserPanelProfile : Page
    {
        public UserPanelProfile()
        {
            InitializeComponent();
            UserPanelProfileViewModel vm = new UserPanelProfileViewModel();
            DataContext = vm;
        }
    }
}