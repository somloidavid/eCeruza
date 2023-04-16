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

        private void cbSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnOsztalyok_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrarend_Click(object sender, RoutedEventArgs e)
        {
            Teacher_Timetable window = new Teacher_Timetable();
            Application.Current.MainWindow.Content = window.Content;
        }

    }
}
