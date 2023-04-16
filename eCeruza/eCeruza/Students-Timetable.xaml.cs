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
                    Label l = new Label();
                    l.VerticalAlignment = VerticalAlignment.Center;
                    l.HorizontalAlignment = HorizontalAlignment.Center;
                    l.FontSize = 25;
                    l.BorderBrush = Brushes.Black;
                    Grid.SetRow(l, j + 1);
                    Grid.SetColumn(l, i);
                    if (Orarend[i, j] == "Idegennyelv")
                    {
                        l.Content = MainWindow.SLoginName.Language;
                        TimeTable.Children.Add(l);
                    }
                    else
                    {
                        l.Content = Orarend[i, j];
                        TimeTable.Children.Add(l);
                    }
                }
            }
        }
    }
}
