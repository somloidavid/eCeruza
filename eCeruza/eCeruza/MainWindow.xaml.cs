using eCeruza.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eCeruza
{
    public partial class MainWindow : Window
    {
        static Dictionary<string, List<string>> subjects = new Dictionary<string, List<string>>();
        static List<Student> students = JsonSerializer.Deserialize<Student[]>(File.ReadAllText("Source/students.json")).ToList();
        static List<Teacher> teachers = JsonSerializer.Deserialize<Teacher[]>(File.ReadAllText("Source/teachers.json")).ToList();
        static Student user = new Student();
        static List<string> allSubjects { get; set; }

        #region Properties
        public static List<string> AllSubjects 
        { 
            get
            {
                return allSubjects;
            }
        }
        public static Dictionary<string, List<string>> Subjects
        { get {return subjects;}}
        static Teacher loginName;
        static public Teacher LoginName {
            get
            {
                return loginName;
            }
        }
        public static List<Student> Students
        {
          get
          {
          return students;
          }
        }
        public static List<Teacher> Teachers
        {
            get
            {
                return teachers;
            }
            set
            {
                teachers = value;
            }
        }
        public static Student User
        {
            get
            {
                return user;
            }
        }
        #endregion
        public MainWindow()
        {
            GetSubjects();
            InitializeComponent();
        }

        public void GetSubjects()
        {
            string className;
            string subject;
            string subject2 = "";
            foreach (Teacher teacher in teachers)
            {
                foreach(KeyValuePair<string, string[]> classSubject in teacher.ClassSubject)
                {
                    className = classSubject.Key;
                    if (classSubject.Value.Length == 1)
                    {
                        subject = classSubject.Value[0];
                    }
                    else
                    {
                        subject = classSubject.Value[0];
                        subject2 = classSubject.Value[1];
                    }
                    if (!subjects.ContainsKey(className) && subject2 == "")
                    {
                        subjects.Add(className, new List<string>() { subject });
                    }
                    else if (!subjects.ContainsKey(className) && subject2 != "")
                    {
                        subjects.Add(className, new List<string>() { subject, subject2 });
                    }
                    if (!subjects[className].Contains(subject))
                    {
                        subjects[className].Add(subject);
                    }
                    if (!subjects[className].Contains(subject2))
                    {
                        subjects[className].Add(subject2);
                    }
                }
            }
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            string name = tb_Name.Text;
            string password = tb_Password.Text;
            int accountType = 0;
            bool correctPassword = false;
            //0-nincs, 1-teacher 2-student
            int index = 0;
            while (accountType == 0 && index < teachers.Count)
            {
                if (teachers[index].Name == name)
                {
                    accountType = 1;
                    if (teachers[index].Password == password)
                    {
                        correctPassword = true;
                        loginName = teachers[index];
                        Teacher_Classes window = new Teacher_Classes();
                        Application.Current.MainWindow.Content = window.Content;

                    }
                }
                index++;
            }
            index = 0;
            while (accountType == 0 && index < students.Count)
            {
                if (students[index].Name == name)
                {
                    accountType = 2;
                    if (students[index].Password == password)
                    {
                        correctPassword = true;
                        user = students[index];
                        allSubjects = User.Subjects;
                        allSubjects.Add(User.Language);
                        allSubjects.Sort();
                        StudentClasses studentClasses = new StudentClasses();
                        Application.Current.MainWindow.Content = studentClasses.Content;
                    }
                }
                index++;
            }
            if (accountType == 0)
            {
                MessageBox.Show("Helytelen Név!");
            }
            else if (!correctPassword)
            {
                MessageBox.Show("Helytelen Jelszó!");
            }
        }

        private void tb_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Opacity = 100;
        }

        private void tb_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Opacity = 100;
        }
    }
}
