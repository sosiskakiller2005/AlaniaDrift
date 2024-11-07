using AlaniaDrift.Model;
using AlaniaDrift.Views.Windows;
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
    /// Логика взаимодействия для CarSearchPage.xaml
    /// </summary>
    public partial class CarSearchPage : Page
    {
        private static AlaniaDriftDbEntities _context = App.GetContext();
        public CarSearchPage()
        {
            InitializeComponent();
            CarsLb.ItemsSource = _context.Car.ToList();
        }

        private void CarsLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CarInfoWindow carInfoWindow = new CarInfoWindow(CarsLb.SelectedItem as Car);
            carInfoWindow.ShowDialog();
        }
    }
}
