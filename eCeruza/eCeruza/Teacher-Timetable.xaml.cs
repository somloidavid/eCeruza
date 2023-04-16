using eCeruza.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        string[,] Orarend = new string[,]{
            {"Idegennyelv","Idegennyelv","Matematika","Fizika","Programozás","Programozás" },
            {"IKT Projektmunka","IKT Projektmunka","Történelem","Irodalom","Nyelvtan","Idegennyelv"},
            {"Programozás","Programozás","Irodalom","Történelem","Idegennyelv","Nyelvtan" },
            {"Matematika","Matematika","Irodalom","Történelem","Programozás","Programozás" },
            {"Idegennyelv","Idegennyelv","Programozás","Programozás","IKT Projektmunka","IKT Projektmunka"}};
        public Teacher_Timetable()
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
                    Grid.SetRow(grid, j+2);
                    Grid.SetColumn(grid, i+1);
                    grid.Children.Add(border);
                    TimeTable.Children.Add(grid);

                     foreach(var item2 in MainWindow.LoginName.ClassSubject.Values)
                     {
                        if (item2.Contains(Orarend[i,j]))
                        {
                            Label l = new Label();
                            l.VerticalAlignment = VerticalAlignment.Center;
                            l.HorizontalAlignment = HorizontalAlignment.Center;
                            l.FontSize = 35;
                            l.Content = Orarend[i, j];
                            //Grid.SetRow(l, j + 2);
                            //Grid.SetColumn(l, i+1);
                            grid.Children.Add(l);
                        }
                     }
                   

                       
                }
            }
            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);
            DateTime weekEnd = currentWeekStartDate.AddDays(+6);
            lblWeek.FontSize = 52;
            lblWeek.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblWeek.VerticalContentAlignment = VerticalAlignment.Center;
            lblWeek.Foreground = Brushes.White;
            lblWeek.Content = $"{currentWeekStartDate.ToString("yyyy,MM,dd").Replace(',','.')}-{weekEnd.ToString("yyyy,MM,dd").Replace(',', '.')}";

                for (int i = 0; i <= 6; i++)
                {
                    for (int j = 0; j <= 9; j++)
                    {

                    }
                }
        }
    }
}
