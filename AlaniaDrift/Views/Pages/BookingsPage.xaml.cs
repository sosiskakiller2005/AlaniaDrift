using AlaniaDrift.AppData;
using AlaniaDrift.Model;
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

namespace AlaniaDrift.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookingsPage.xaml
    /// </summary>
    public partial class BookingsPage : Page
    {
        private static AlaniaDriftDbEntities _context = App.GetContext();
        public BookingsPage()
        {
            InitializeComponent();
            BookingsDg.ItemsSource = _context.Booking.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new MenuPage());
        }
    }
}
