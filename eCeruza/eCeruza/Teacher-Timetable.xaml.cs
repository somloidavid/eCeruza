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
        //List<Dictionary<string, Dictionary<string, string>>> z = JsonSerializer.Deserialize<>(File.ReadAllText("Source/TimeTable.json")).ToList();
        List<Dictionary<string, Dictionary<int, string>>> s =new List<Dictionary<string, Dictionary<int, string>>> { new Dictionary<string, Dictionary<int, string>> { { "Hétfő", new Dictionary<int, string> { { 1, "Idegennyelv" }, { 2, "Idegennyelv" }, { 3, "Matematika"}, { 4, "Fizika"}, { 5, "Programozás"}, { 6, "Programozás"} } } } };
        string[,] Orarend = new string[,]{
            {"Idegennyelv","Idegennyelv","Matematika","Fizika","Programozás","Programozás" },
            {"IKT Projektmunka","IKT Projektmunka","Történelem","Irodalom","Nyelvtan","Idegennyelv"},
            {"Programozás","Programozás","Irodalom","Történelem","Idegennyelv","Nyelvtan" },
            {"Matematika","Matematika","Irodalom","Történelem","Programozás","Programozás" },
            {"Idegennyelv","Idegennyelv","Programozás","Programozás","IKT Projektmunka","IKT Projektmunka"}};
        public Teacher_Timetable()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            MessageBox.Show($"{now.DayOfWeek}");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Label l = new Label();
                    l.Content = Orarend[i, j];
                    Grid.SetRow(l, j);
                    Grid.SetColumn(l, i);
                    TimeTable.Children.Add(l);
                }
            }
        }
    }
}
