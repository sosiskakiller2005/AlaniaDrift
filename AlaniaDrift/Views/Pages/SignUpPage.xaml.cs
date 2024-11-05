using AlaniaDrift.AppData;
using AlaniaDrift.Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private static AlaniaDriftDbEntities _context = App.GetContext();
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LastnameTb.Text) || string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(SurnameTB.Text) 
                || string.IsNullOrEmpty(PhoneNUmberTb.Text) || string.IsNullOrEmpty(EmailTb.Text) || string.IsNullOrEmpty(PassTB.Password))
            {
                MessageBoxHelper.Error("Заполните все поля для ввода.");
            }
            else
            {
                User newUser = new User()
                {
                    Lastname = LastnameTb.Text,
                    Name = NameTb.Text,
                    Surname = SurnameTB.Text,
                    PhoneNumber = PhoneNUmberTb.Text,
                    Email = EmailTb.Text,
                    Password = PassTB.Password,
                    IsVerified = false
                };
                _context.User.Add(newUser);
                _context.SaveChanges();
                MessageBoxHelper.Information("Новый пользователь создан.");
                FrameHelper.selectedFrame.GoBack();
            }
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
