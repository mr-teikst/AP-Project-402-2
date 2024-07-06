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
using Final_Project.ViewModels.UserControlsViewModel;

namespace Final_Project.Views.UserControls
{
    /// <summary>
    /// Interaction logic for OrderHistoryItemUserControl.xaml
    /// </summary>
    public partial class OrderHistoryItemUserControl : UserControl
    {
        public OrderHistoryItemUserControl()
        {
            InitializeComponent();
            OrderHistoryItemViewModel vm = new OrderHistoryItemViewModel();
            DataContext = vm;
        }
    }
}