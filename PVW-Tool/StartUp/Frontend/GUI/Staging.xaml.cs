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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StartUp.Frontend.GUI
{
    /// <summary>
    /// Interaction logic for Staging.xaml
    /// </summary>
    public partial class Staging : Window
    {
        public Staging()
        {
            InitializeComponent();
        }

        private void btnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("SbHideLeftMenu", BtnLeftMenuHide, BtnLeftMenuShow, PnlLeftMenu);
        }

        private void btnLeftMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("SbShowLeftMenu", BtnLeftMenuHide, BtnLeftMenuShow, PnlLeftMenu);
        }

        private void ShowHideMenu(string Storyboard, UIElement btnHide, UIElement btnShow, FrameworkElement pnl)
        {
            var sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }

        void BtnAddUser_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ADDMEE");
        }
    }
}
