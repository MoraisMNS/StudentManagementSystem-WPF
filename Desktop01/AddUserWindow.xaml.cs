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
using System.Windows.Shapes;

namespace Desktop01
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow(AddUserVM vm)

        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

           
            if (main != null)
            {
                main.WindowState = WindowState.Normal;
                main.Activate();
            }
            else
            {
               
                main = new MainWindow();
                main.Show();
            }

         
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            fnametxt.Text = string.Empty;
            lnametxt.Text = string.Empty;

            dobtxt.Text = string.Empty;
            int intValue;
            if (int.TryParse(agetxt.Text, out intValue))
            {
                agetxt.Text = "0";
            }
            else
            {
                agetxt.Text = string.Empty;
            }

            double doubleValue;
            if (double.TryParse(gpatxt.Text, out doubleValue))
            {
                gpatxt.Text = "0.0";
            }
            else
            {
                gpatxt.Text = string.Empty;
            }

            depttxt.Text = string.Empty;
            acadadvtxt.Text = string.Empty;

            

            /*private void GpaText_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (!char.IsDigit(GpaText.Text, GpaText.Text.Length - 1) && GpaText.Text != ".")
                {
                    e.Handled = true;
                }
            }*/
        }

        private void depttxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string userInput = depttxt.Text;
        }

        private void acadadvtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            string userInput = acadadvtxt.Text;

        }
      

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}



