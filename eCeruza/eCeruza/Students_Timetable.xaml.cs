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
    /// Interaction logic for Students_Timetable.xaml
    /// </summary>
    public partial class Students_Timetable : Window
    {
        private void button_TimeTable_Click(object sender, MouseButtonEventArgs e)
        {
            Teacher_Classes w = new Teacher_Classes();
            Application.Current.MainWindow.Content = w.Content;
        }

        private void button_Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow w = new MainWindow();
            Application.Current.MainWindow.Content = w.Content;
        }
        private void button_logoutClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        string[,] Orarend = new string[,]{
            {"Idegennyelv","Idegennyelv","Matematika","Fizika","Programozás","Programozás" },
            {"IKT Projektmunka","IKT Projektmunka","Történelem","Irodalom","Nyelvtan","Idegennyelv"},
            {"Programozás","Programozás","Irodalom","Történelem","Idegennyelv","Nyelvtan" },
            {"Matematika","Matematika","Irodalom","Történelem","Programozás","Programozás" },
            {"Idegennyelv","Idegennyelv","Programozás","Programozás","IKT Projektmunka","IKT Projektmunka"}};
        public Students_Timetable()
        {

            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid grid = new Grid();
                    Border border = new Border();
                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(2);
                    Grid.SetRow(grid, j + 2);
                    Grid.SetColumn(grid, i + 1);
                    grid.Children.Add(border);
                    TimeTable.Children.Add(grid);


                    Label l = new Label();
                    l.VerticalAlignment = VerticalAlignment.Center;
                    l.HorizontalAlignment = HorizontalAlignment.Center;
                    l.FontSize = 35;
                    //Grid.SetRow(l, j + 1);
                    //Grid.SetColumn(l, i);
                    if (Orarend[i, j] == "Idegennyelv")
                    {
                        l.Content = MainWindow.User.Language;
                        grid.Children.Add(l);
                    }
                    else
                    {
                        l.Content = Orarend[i, j];
                        grid.Children.Add(l);
                    }
                }
            }
            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);
            DateTime weekEnd = currentWeekStartDate.AddDays(+6);
            lblWeek1.FontSize = 52;
            lblWeek1.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblWeek1.VerticalContentAlignment = VerticalAlignment.Center;
            lblWeek1.Foreground = Brushes.White;
            lblWeek1.Content = $"{currentWeekStartDate.ToString("yyyy,MM,dd").Replace(',', '.')}-{weekEnd.ToString("yyyy,MM,dd").Replace(',', '.')}";

        }
    }
}
