using AlaniaDrift.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для BookingPage.xaml  
    /// </summary>  
    public partial class BookingPage : Page
    {
        private static AlaniaDriftDbEntities _context = App.GetContext();

        public BookingPage()
        {
            InitializeComponent();
            UserCmb.ItemsSource = _context.User.ToList();
            UserCmb.DisplayMemberPath = "Fullname";
            CarCmb.ItemsSource = _context.Car.ToList();
            CarCmb.DisplayMemberPath = "Model.Name";
            TrackCmb.ItemsSource = _context.Track.ToList();
            TrackCmb.DisplayMemberPath = "Name";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserCmb.SelectedItem != null && CarCmb.SelectedItem != null && StartDp.SelectedDate != null && EndDp.SelectedDate != null && TrackCmb.SelectedItem != null)
            {
                if (StartDp.SelectedDate > EndDp.SelectedDate)
                {
                    MessageBoxHelper.Error("Дата начала бронирования не может быть позже даты окончания бронирования");
                    return;
                }
                var selectedCar = CarCmb.SelectedItem as Car;
                if (selectedCar == null)
                {
                    MessageBoxHelper.Error("Выберите машину.");
                    return;
                }

                var startDate = StartDp.SelectedDate.Value;
                var endDate = EndDp.SelectedDate.Value;

                bool isExist = _context.Booking.Any(b => b.CarId == selectedCar.Id &&
                   ((startDate >= b.StartDate && startDate <= b.EndDate) ||
                    (endDate >= b.StartDate && endDate <= b.EndDate) ||
                    (startDate <= b.StartDate && endDate >= b.EndDate)));

                if (isExist == true)
                {
                    MessageBoxHelper.Error("Выбранная машина уже забронирована на указанный период");
                }
                else
                {
                    Booking booking = new Booking
                    {
                        UserId = (UserCmb.SelectedItem as User).Id,
                        CarId = (CarCmb.SelectedItem as Car).Id,
                        StartDate = StartDp.SelectedDate.Value,
                        EndDate = EndDp.SelectedDate.Value,
                        TrackId = (TrackCmb.SelectedItem as Track).Id
                    };

                    _context.Booking.Add(booking);
                    _context.SaveChanges();
                    MessageBoxHelper.Information("Бронирование успешно добавлено");
                }
            }
            else
            {
                MessageBoxHelper.Error("Пожалуйста, заполните все поля");
            }
        }
    }
}
