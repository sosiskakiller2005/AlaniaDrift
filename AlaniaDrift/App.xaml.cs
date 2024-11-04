using AlaniaDrift.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AlaniaDrift
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static AlaniaDriftDbEntities _context;
        public static AlaniaDriftDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new AlaniaDriftDbEntities();
            }
            return _context;
        }
    }
}
