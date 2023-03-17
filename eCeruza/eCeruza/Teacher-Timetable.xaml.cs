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

namespace eCeruza
{
    /// <summary>
    /// Interaction logic for Teacher_Timetable.xaml
    /// </summary>
    public partial class Teacher_Timetable : Window
    {
        public Teacher_Timetable()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            MessageBox.Show($"{now.DayOfWeek}");
        }
    }
}
