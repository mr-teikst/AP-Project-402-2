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

        private string _NameField;
        public string NameField {
            get { return _NameField; }
            set 
            { 
                _NameField = value;
                vm.NameField = value;
            }
        }

        private string _HintField;
        public string HintField { 
            get { return _HintField; } 
            set 
            {
                _HintField = value;
                vm.HintField = value;
            }
        }

        private string _TextField;
        public string TextField
        {
            get { return _TextField; }
            set 
            {
                _TextField = value;
                vm.TextField = value;
            }
        }

        private bool _EnabilityField = true;
        public bool EnabilityField
        {
            get { return _EnabilityField; }
            set
            {
                _EnabilityField = value;
                vm.EnabilityField = value;
            }
        }


        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            textTXB.Clear();
            textTXB.Focus();
        }

    }
}
