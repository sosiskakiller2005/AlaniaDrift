﻿using AlaniaDrift.AppData;
using AlaniaDrift.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Universitet.AppData;

namespace AlaniaDrift.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationPage.xaml
    /// </summary>
    public partial class AuthorisationPage : Page
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        public AuthorisationPage()
        {
            InitializeComponent();
        }

        private void EntryBTn_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorisationHelper.Authorise(PhoneNUmberTb.Text+"          ", PassTB.Password))
            {
                if (AuthorisationHelper.selectedUser.IsVerified == true)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Window.GetWindow(this).Close();
                }
                else
                {
                    FrameHelper.selectedFrame.Navigate(new VerifyPage());
                }
            }
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new SignUpPage());
        }

        private void PhoneNUmberTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
