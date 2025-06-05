using AlaniaDrift.AppData;
using AlaniaDrift.Views.Pages;
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
using System.Windows.Shapes;

namespace AlaniaDrift.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameHelper.selectedFrame = MainFrm;
            MainFrm.Navigate(new MenuPage());
        }
        private void CarSearchMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new CarSearchPage());
        }

        private void TrackCarSearchMI_Click(object sender, RoutedEventArgs e)
        {
            TracksPage tracksPage = new TracksPage();
            MainFrm.Navigate(tracksPage);
        }

        private void BookingMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new BookingPage());
        }

        private void BookingsMI_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new BookingsPage());

        }
    }
}
