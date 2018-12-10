using System;
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

namespace StartUp.Frontend.GUI
{
    /// <summary>
    /// Interaction logic for GUI.xaml
    /// </summary>
    public partial class GUI : Window
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("AddEmployee");
        }

        private void ChangeEmployee(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ChangeEmployee");
        }
    }
}
