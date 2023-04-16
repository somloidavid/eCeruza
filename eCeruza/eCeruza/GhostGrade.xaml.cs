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
    public partial class GhostGrade : Window
    {
        static BrushConverter bc = new BrushConverter();
        string brush = "#FF962C2B";
        Dictionary<int, int> grades = new Dictionary<int, int> { { 1 , 0 } , { 2, 0 } , { 3, 0 }, { 4, 0 }, { 5, 0 } };
        public Label Current { get; set; }
        double Avg = StudentClasses.avgGrades[StudentClasses.SelectedSubject];
        int count = StudentGrades.gradesInSubject.Count;
        double sum;

        public GhostGrade()
        {
            InitializeComponent();
            sum = Avg * count;
            lbl_Avg.Content = Math.Round(sum/count, 2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            Label szendrei = sender as Label;
            Current = szendrei;
            Label? selected = null;
            foreach (object obj in grd_Values.Children)
            {
                Label label = (Label)obj;
                string color = label.Background.ToString();
                if (color == brush)
                {
                    selected = label;
                }
            }
            if (selected != null)
            {
                selected.Background = (Brush)bc.ConvertFrom("#FF830C0B");
            }
            szendrei.Background = (Brush)bc.ConvertFrom("#FF962C2B");
            lbl_Number.Content = grades[int.Parse(Current.Content.ToString())];
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid.Name == "s" && grades[int.Parse(Current.Content.ToString())] > 0)
            {
                grades[int.Parse(Current.Content.ToString())]--;
                Average(false);
            }
            else if (grid.Name == "a")
            {
                grades[int.Parse(Current.Content.ToString())]++;
                Average(true);
            }
            lbl_Number.Content = grades[int.Parse(Current.Content.ToString())];
            
        }

        private void Average(bool add)
        {
            if (add)
            {
                sum += int.Parse(Current.Content.ToString());
                count++;
            }
            else
            {
                sum -= int.Parse(Current.Content.ToString());
                count--;
            }
            Avg = sum/count;
            lbl_Avg.Content = Math.Round(Avg, 2);
        }

        private void lbl_Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StudentGrades.GG.Close();
        }
    }
}
