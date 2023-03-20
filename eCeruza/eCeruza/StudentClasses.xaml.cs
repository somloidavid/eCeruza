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
    public partial class StudentClasses : Window
    {
        static public string SelectedSubject { get; set; }
        public StudentClasses()
        {
            InitializeComponent();
            Dictionary<string, double> avgGrades = Average();
            List<string> allSubjects = MainWindow.User.Subjects;
            allSubjects.Add(MainWindow.User.Language);
            for (int i = 0; i < 8; i++)
            {
                Grid grd = new Grid();
                Label lbl = new Label();
                lbl.Content = allSubjects[i];
                Label lbl1 = new Label();
                lbl1.Margin = new Thickness(200, 0, 0, 0);
                lbl1.Content = avgGrades[allSubjects[i]];
                grd.Children.Add(lbl);
                grd.Children.Add(lbl1);
                Grid grid = grd_Container.Children[i] as Grid;
                grid.Children.Add(grd);
            }
        }

        public Dictionary<string, double> Average()
        {
            Dictionary<string, double[]> totalGrades = new Dictionary<string, double[]>();
            Dictionary<string, double> avgGrades = new Dictionary<string, double>();
            foreach (Grade grade in MainWindow.User.Grades)
            {
                if (!totalGrades.ContainsKey(grade.Subject))
                {
                    totalGrades.Add(grade.Subject, new double[] {grade.Value, 1});
                }
                else
                {
                    totalGrades[grade.Subject] = new double[] { totalGrades[grade.Subject][0] + grade.Value , totalGrades[grade.Subject][1] +1};
                }
            }
            foreach (KeyValuePair<string, double[]> kv in totalGrades)
            {
                avgGrades.Add(kv.Key, Math.Round(kv.Value[0] / kv.Value[1], 2));
            }
            return avgGrades;
        }

        private void grd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid grd = sender as Grid;
            Grid containerGrid = grd.Children[0] as Grid;
            Label subjectLabel = containerGrid.Children[0] as Label;
            StudentClasses.SelectedSubject = subjectLabel.Content.ToString();
            StudentGrades studentGrades = new StudentGrades();
            Application.Current.MainWindow.Content = studentGrades.Content;
        }
    }
}
