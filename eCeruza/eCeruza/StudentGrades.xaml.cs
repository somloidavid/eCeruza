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
        public StudentGrades()
        {
            InitializeComponent();
            FillContent();
        }

        public void FillContent()
        {
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
        }
    }
}
