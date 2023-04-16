using eCeruza.Classes;
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
    /// Interaction logic for Teacher_Classes.xaml
    /// </summary>
    public partial class Teacher_Classes : Window
    {
        
        public Teacher_Classes()
        {
            InitializeComponent();
            InitializeClasses();
        }

        private void InitializeClasses()
        {
            
            int lblIndex = 1;
            foreach (var item in MainWindow.LoginName.ClassSubject)
            {
             
                Label lblName = this.FindName($"lbl{lblIndex++}") as Label;
                lblName.Content = item.Key;
                lblName.FontSize = 52;
                lblName.HorizontalContentAlignment = HorizontalAlignment.Center;
                lblName.VerticalContentAlignment = VerticalAlignment.Center;
                //lblName.HorizontalAlignment = HorizontalAlignment.Center;
                //lblName.VerticalAlignment = VerticalAlignment.Center;
                lblName.Visibility = Visibility.Visible;
            }
            

        }

        private void LB_Click(object sender, RoutedEventArgs e)
        {
            TeacherClass w = new TeacherClass();
            Application.Current.MainWindow.Content = w.Content;
        }

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


    }
}
