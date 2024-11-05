using AlaniaDrift.AppData;
using AlaniaDrift.Model;
using Microsoft.Win32;
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
using Universitet.AppData;

namespace AlaniaDrift.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для VerifyPage.xaml
    /// </summary>
    public partial class VerifyPage : Page
    {
        private static AlaniaDriftDbEntities _context = App.GetContext();
        static List<Documents> documents = _context.Documents.ToList();
        Documents _userDocuments = documents.FirstOrDefault(d => d.User == AuthorisationHelper.selectedUser);
        Documents _newDocuments = new Documents();
        public VerifyPage()
        {
            InitializeComponent();
            _newDocuments.User = AuthorisationHelper.selectedUser;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_newDocuments.Passport != null && _newDocuments.SNILS != null && _newDocuments.INN != null)
            {
                _context.Documents.Add(_newDocuments);
                _context.SaveChanges();
                MessageBoxHelper.Information("Документы добавлены. Ожидайте подтверждение аккаунта.");
                FrameHelper.selectedFrame.GoBack();
            }
        }

        private void AddPassportBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.pdf)|*.jpg;*.jpeg;*.png;*.pdf";
            if (openFileDialog.ShowDialog() == true)
            {
                if (UploadImage(openFileDialog.FileName, "Passport"))
                {
                    PassportTbl.Visibility = Visibility.Visible;
                }
            }
        }
        private void AddINNBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.pdf)|*.jpg;*.jpeg;*.png;*.pdf";
            if (openFileDialog.ShowDialog() == true)
            {
                if (UploadImage(openFileDialog.FileName, "INN"))
                {
                    INNTbl.Visibility = Visibility.Visible;
                }
            }
        }

        private void AddSnilsBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.pdf)|*.jpg;*.jpeg;*.png;*.pdf";
            if (openFileDialog.ShowDialog() == true)
            {
                if (UploadImage(openFileDialog.FileName, "SNILS"))
                {
                    SNILSBTn.Visibility = Visibility.Visible;
                }
            }
        }
        private bool UploadImage(string fileName, string documentName)
        {
            try
            {
                // Получаем выбранный файл в массив байтов
                byte[] imageData = File.ReadAllBytes(fileName);

                // Сохраняем изображение в базе данных
                switch (documentName)
                {
                    case "Passport":
                        _newDocuments.Passport = imageData;
                        break;
                    case "INN":
                        _newDocuments.INN = imageData;
                        break;
                    case "SNILS":
                        _newDocuments.SNILS = imageData;
                        break;
                    default:
                        break;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Error($"Ошибка при добавлении фотографии: {ex.Message}");
                return false;
            }
        }
    }
}
