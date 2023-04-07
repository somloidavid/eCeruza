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
        #region Colors
        static BrushConverter bc = new();
        public static Brush yellow = (Brush)bc.ConvertFrom("#FFA500");
        public static Brush grey = (Brush)bc.ConvertFrom("#FFD4D4D4");
        #endregion
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
                #region Initialize
                RowDefinition rd = new();
                rd.Height = new GridLength(150);
                Grid grd_Grade = new();
                Label lbl_Value = new();
                Label lbl_Message = new();
                Label lbl_Date = new();
                Border border = new Border();
                #endregion
                #region GradeStyle
                grd_Grade.Height = 120;
                grd_Grade.Width = 700;
                grd_Grade.Margin = new Thickness(0, 20, 0, 0);
                border.CornerRadius = new CornerRadius(30);
                border.Background = grey;
                #endregion
                #region LabelStyle
                #region FontColor
                lbl_Value.Foreground = yellow;
                lbl_Message.Foreground = yellow;
                lbl_Date.Foreground = yellow;
                #endregion
                #region FontSize
                lbl_Value.FontSize = 34;
                lbl_Message.FontSize = 34;
                lbl_Date.FontSize = 34;
                #endregion
                #region Content
                lbl_Value.Content = gradesInSubject[i].Value;
                lbl_Message.Content = gradesInSubject[i].Message;
                lbl_Date.Content = gradesInSubject[i].Date;
                #endregion
                #region Width
                lbl_Value.Width = 50;
                lbl_Message.Width = 300;
                lbl_Date.Width = 400;
                #endregion
                #region Height
                lbl_Value.Height = 120;
                lbl_Message.Height = 120;
                lbl_Date.Height = 120;
                #endregion
                #region Margin
                lbl_Value.Margin = new Thickness(0, 0, 500, 0);
                lbl_Date.Margin = new Thickness(500, 0, 0, 0);
                #endregion
                #endregion
                #region Add
                grd_Grade.Children.Add(border);
                grd_Grade.Children.Add(lbl_Value);
                grd_Grade.Children.Add(lbl_Message);
                grd_Grade.Children.Add(lbl_Date);
                grd_Grades.RowDefinitions.Add(rd);
                Grid.SetRow(grd_Grade, i);
                grd_Grades.Children.Add(grd_Grade);
                #endregion
            }
        }

        private void btn_Classes_Click(object sender, RoutedEventArgs e)
        {
            StudentClasses studentClasses = new StudentClasses();
            Application.Current.MainWindow.Content = studentClasses.Content;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GhostGrade gg = new();
            gg.Show();
        }
    }
}
