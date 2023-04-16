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
                    
                     foreach(var item2 in MainWindow.LoginName.ClassSubject.Values)
                     {
                        if (item2.Contains(Orarend[i,j]))
                        {
                            Label l = new Label();
                            l.VerticalAlignment = VerticalAlignment.Center;
                            l.HorizontalAlignment = HorizontalAlignment.Center;
                            l.FontSize = 25;
                            l.BorderBrush = Brushes.Black;
                            l.Content = Orarend[i, j];
                            Grid.SetRow(l, j + 1);
                            Grid.SetColumn(l, i);
                            TimeTable.Children.Add(l);
                        }
                     }
                   

                       
                }
            }
        }
    }
}
