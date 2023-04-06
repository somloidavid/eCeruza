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
    public partial class StudentGrades : Window
    {
        public List<Grade> gradesInSubject = new();
        public StudentGrades()
        {
            foreach (Grade grade in MainWindow.User.Grades)
            {
                if (grade.Subject == StudentClasses.SelectedSubject)
                {
                    gradesInSubject.Add(grade);
                }
            }
            InitializeComponent();
            FillContent();
        }

        public void FillContent()
        {
            grd_Grades.Height = gradesInSubject.Count * 150;
            Teacher teacher = new Teacher();
            lbl_Subject.Content = StudentClasses.SelectedSubject;
            foreach (Teacher tchr in MainWindow.Teachers)
            {
                foreach (KeyValuePair<string, string[]> classSubject in tchr.ClassSubject)
                {
                    if (classSubject.Key == MainWindow.User.Class && classSubject.Value.Contains(StudentClasses.SelectedSubject))
                    {
                        teacher = tchr;
                    }
                }
            }
            lbl_Teacher.Content = teacher.Name;
            for (int i = 0; i < gradesInSubject.Count; i++)
            {
                RowDefinition rd = new();
                BrushConverter bc = new();
                Brush yellow = (Brush)bc.ConvertFrom("#FFA500");
                yellow.Freeze();
                rd.Height = new GridLength(150);
                grd_Grades.RowDefinitions.Add(rd);
                Grid griddy = new();
                griddy.Width = 800;
                griddy.Height = 900 / 6;
                griddy.Width = 800;
                grd_Grades.Children.Add(griddy);
                Grid.SetRow(griddy, i);
                Label lbl_Value = new();
                Label lbl_Message = new();
                Label lbl_Date = new();
                lbl_Value.Foreground = yellow;
                lbl_Message.Foreground = yellow;
                lbl_Date.Foreground = yellow;
                lbl_Value.FontSize = 30;
                lbl_Message.FontSize = 30;
                lbl_Date.FontSize = 30;
                lbl_Value.Content = gradesInSubject[i].Value;
                lbl_Message.Content = gradesInSubject[i].Message;
                lbl_Date.Content = gradesInSubject[i].Date;
                lbl_Value.Width = 50;
                lbl_Message.Width = 300;
                lbl_Date.Width = 400;
                lbl_Value.Height = 900 / 6;
                lbl_Message.Height = 900 / 6;
                lbl_Date.Height = 900 / 6;
                lbl_Value.Margin = new Thickness(0, 0, 750, 0);
                lbl_Date.Margin = new Thickness(600, 0, 0, 0);
                lbl_Value.FontSize = 34;
                lbl_Message.FontSize = 34;
                lbl_Date.FontSize = 34;
                griddy.Children.Add(lbl_Value);
                griddy.Children.Add(lbl_Message);
                griddy.Children.Add(lbl_Date);
            }
        }

        private void btn_Classes_Click(object sender, RoutedEventArgs e)
        {
            StudentClasses studentClasses = new StudentClasses();
            Application.Current.MainWindow.Content = studentClasses.Content;
        }
    }
}
