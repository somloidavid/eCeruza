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
        static private SortedList<string, double> classAvg = new();
        static public SortedList<string, double> ClassAvg { get { return classAvg; } }
        static public Dictionary<string, double> avgGrades { get; set; }
        public CornerRadius CornerRadius { get; set; }

        public StudentClasses()
        {
            InitializeComponent();
            avgGrades = Average();
            FillContent();
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
            Grid gridu = grd.Children[0] as Grid;
            Label subjectLabel = gridu.Children[0] as Label;
            StudentClasses.SelectedSubject = subjectLabel.Content.ToString();
            StudentGrades studentGrades = new StudentGrades();
            Application.Current.MainWindow.Content = studentGrades.Content;
        }

        private void CalculateClassAvg(string subject)
        {
            double sum = 0;
            int count = 0;
            double avg = 0;
            foreach (Student student in MainWindow.Students)
            {
                if (student.Class == MainWindow.User.Class)
                {
                    foreach (Grade grade in student.Grades)
                    {
                        if(grade.Subject == subject)
                        {
                            sum += grade.Value;
                            count++;
                        }
                    }
                }
            }
            avg = sum / count;
            if (ClassAvg.ContainsKey(subject))
            {
                ClassAvg[subject] = Math.Round(avg, 2);
            }
            else
            {
                ClassAvg.Add(subject, Math.Round(avg, 2));
            }
        }
        private void FillContent()
        {
            for (int i = 0; i < 8; i++)
            {
                CalculateClassAvg(MainWindow.AllSubjects[i]);
                Grid grd = new Grid();
                Label lbl_Subject = new Label();
                lbl_Subject.Content = MainWindow.AllSubjects[i];
                Label lbl_Avg = new Label();
                lbl_Avg.Margin = new Thickness(200, 0, 0, 0);
                lbl_Avg.Content = avgGrades[MainWindow.AllSubjects[i]];
                Label lbl_ClassAvg = new Label();
                lbl_ClassAvg.Margin = new Thickness(250, 0, 0, 0);
                lbl_ClassAvg.Content = ClassAvg[MainWindow.AllSubjects[i]];
                grd.Children.Add(lbl_Subject);
                grd.Children.Add(lbl_Avg);
                grd.Children.Add(lbl_ClassAvg);
                Grid grid = grd_Container.Children[i] as Grid;
                grid.Children.Add(grd);
            }
        }
    }
}
