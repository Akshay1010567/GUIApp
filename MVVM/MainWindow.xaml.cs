using System;
using System.Collections.Generic;
using System.IO;
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
using System.Text.RegularExpressions;

namespace MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void MinVoltageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                if (viewModel.MinVoltage < 16 || viewModel.MinVoltage > 249)
                {
                    MessageBox.Show("Min Voltage must be between 16 and 249 volts.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    viewModel.ApplyMinVoltage();
                }
            }
        }

        private void MaxVoltageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                if (viewModel.MaxVoltage < 16 || viewModel.MaxVoltage > 249)
                {
                    MessageBox.Show("Max Voltage must be between 16 and 249 volts.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    viewModel.ApplyMaxVoltage();
                }
            }
        }
    }

}
