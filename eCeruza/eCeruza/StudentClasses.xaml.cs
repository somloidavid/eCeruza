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
            Grid gridu = grd.Children[1] as Grid;
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
                BrushConverter bc = new();
                Brush yellow = (Brush)bc.ConvertFrom("#FFA500");
                yellow.Freeze();
                CalculateClassAvg(MainWindow.AllSubjects[i]);
                Grid grd = new Grid();
                Label lbl_Subject = new Label();
                lbl_Subject.Content = MainWindow.AllSubjects[i];
                Label lbl_Avg = new Label();
                lbl_Avg.Margin = new Thickness(400, 0, 0, 0);
                lbl_Avg.Content = avgGrades[MainWindow.AllSubjects[i]];
                Label lbl_ClassAvg = new Label();
                Label person = new Label();
                person.Background = new ImageBrush(new BitmapImage(new Uri("Source/img/person.png", UriKind.Relative)));
                person.Height = 50;
                person.Width = 50;
                person.Margin = new Thickness(50, 0, 0, 0);
                Label people = new Label();
                people.Background = new ImageBrush(new BitmapImage(new Uri("Source/img/people.png", UriKind.Relative)));
                people.Height = 50;
                people.Width = 50;
                people.Margin = new Thickness(450, 0, 0, 0);
                lbl_ClassAvg.Margin = new Thickness(600, 0, 0, 0);
                lbl_ClassAvg.Content = ClassAvg[MainWindow.AllSubjects[i]];
                lbl_Subject.Foreground = yellow;
                lbl_Avg.Foreground = yellow;
                lbl_ClassAvg.Foreground = yellow;
                lbl_Subject.FontSize = 32;
                lbl_Avg.FontSize = 32;
                lbl_Subject.VerticalAlignment = VerticalAlignment.Center;
                lbl_Avg.VerticalAlignment = VerticalAlignment.Center;
                lbl_ClassAvg.VerticalAlignment = VerticalAlignment.Center;
                lbl_ClassAvg.FontSize = 32;
                grd.Margin = new Thickness(50, 0, 0, 0);
                grd.Cursor = Cursors.Hand;
                grd.Children.Add(lbl_Subject);
                grd.Children.Add(person);
                grd.Children.Add(lbl_Avg);
                grd.Children.Add(people);
                grd.Children.Add(lbl_ClassAvg);
                Grid grid = grd_Container.Children[i] as Grid;
                grid.Children.Add(grd);
            }
        }

        private void button_TimeTable_Click(object sender, RoutedEventArgs e)
        {
            Students_Timetable w = new Students_Timetable();
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
