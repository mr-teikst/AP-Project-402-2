using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Final_Project.MVVM;
using Final_Project.ViewModels.UserControlsViewModel;

namespace Final_Project.View.UserControls
{
    /// <summary>
    /// Interaction logic for TextInput.xaml
    /// </summary>
    public partial class TextInput : UserControl
    {
        TextInputViewModel vm;
        public TextInput()
        {
            InitializeComponent();
            vm = new TextInputViewModel();
            DataContext = vm;
        }


        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            textTXB.Clear();
            textTXB.Focus();
        }

    }
}
