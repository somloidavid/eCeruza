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
    /// Interaction logic for TeacherClass.xaml
    /// </summary>
    public partial class TeacherClass : Window
    {

        private void button_TimeTable_Click(object sender, RoutedEventArgs e)
        {
            Teacher_Timetable w = new Teacher_Timetable();
            Application.Current.MainWindow.Content = w.Content;
        }

        private void button_Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StudentGrades.button_Logout_Click(sender, e);
        }

        private void button_logoutClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StudentGrades.button_logoutClose_Click(sender, e);
        }
        public TeacherClass()
        {
            InitializeComponent();
        }

        
    }
}
