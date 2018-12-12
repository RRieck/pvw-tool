using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using StartUp.Fachkonzepte;
using StartUp.Model;
using MessageBox = System.Windows.Forms.MessageBox;

namespace StartUp.Frontend.GUI
{
    /// <summary>
    /// Interaction logic for Staging.xaml
    /// </summary>
    public partial class Staging : Window
    {
        public Fachkonzept1 Fachkonzept { get; set; }
        //public Fachkonzept2 Fachkonzept { get; set; }

        public List<string> Departments = new List<string>()
        {
            "Personalabteilung",
            "Entwickler",
            "Netzwerk",
            "Managment"
        };

        public Staging()
        {
            Fachkonzept = new Fachkonzept1();
            //Fachkonzept = new Fachkonzept2();

            InitializeComponent();

            CbDepartment.ItemsSource = Departments;
            CbChangedDepartment.ItemsSource = Departments;
            CbDepartment.SelectedItem = Departments[0];

            DgContent.ItemsSource = Fachkonzept.GetEmployees();
        }

        void BtnAddUser_OnClick(object sender, RoutedEventArgs e)
        {
            if (Infrastructure.Validator.Validate.CheckTextboxNameValid(TbNewUser.Text))
            {
                Fachkonzept.CreateEmployee(TbNewUser.Text, CbDepartment.SelectedItem.ToString());
                DgContent.ItemsSource = Fachkonzept.GetEmployees();
            }
            else
                MessageBox.Show("Das Eingabeformat ist nicht gültig");
        }

        void BtnShowAllEmployees_OnClick(object sender, RoutedEventArgs e)
        {
            DgContent.ItemsSource = Fachkonzept.GetEmployees();
        }

        void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            DgContent.ItemsSource = Fachkonzept.SearchFor(TbSearchDepartment.Text, TbSearchUser.Text, null);
        }

        void BtnSaveChangedUser_OnClick(object sender, RoutedEventArgs e)
        {
            if (Infrastructure.Validator.Validate.CheckTextboxNameValid(TbChangedUser.Text))
            {
                Fachkonzept.ChangeEmployee(TbUserID.Text, TbChangedUser.Text, CbChangedDepartment.SelectedItem.ToString());
                DgContent.ItemsSource = Fachkonzept.GetEmployees();
            }
            else
                MessageBox.Show("Name nicht Valide");
        }

        void BtnDeletelEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            try{
                var employeesCount = DgContent.SelectedItems.Count;

                for (int i = 0; i < employeesCount; i++)
                {
                    var employee = DgContent.SelectedItems[i] as Employee;
                    Fachkonzept.DeleteEmployee(employee.Id);
                }
                DgContent.ItemsSource = Fachkonzept.GetEmployees();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }


        //Animations
        void BtnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("SbHideLeftMenu", BtnLeftMenuHide, BtnLeftMenuShow, PnlLeftMenu);
        }

        void BtnLeftMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("SbShowLeftMenu", BtnLeftMenuHide, BtnLeftMenuShow, PnlLeftMenu);
        }

        void ShowHideMenu(string storyboard, UIElement btnHide, UIElement btnShow, FrameworkElement pnl)
        {
            var sb = Resources[storyboard] as Storyboard;
            sb.Begin(pnl);

            if (storyboard.Contains("Show"))
            {
                btnHide.Visibility = Visibility.Visible;
                btnShow.Visibility = Visibility.Hidden;
            }
            else if (storyboard.Contains("Hide"))
            {
                btnHide.Visibility = Visibility.Hidden;
                btnShow.Visibility = Visibility.Visible;
            }
        }

        void DgContent_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            try{
                var employee = DgContent.SelectedItems[0] as Employee;

                TbUserID.Text = employee.Id;
                TbChangedUser.Text = employee.Name;
                CbChangedDepartment.SelectedItem = employee.Abteilung;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }


    }
}
