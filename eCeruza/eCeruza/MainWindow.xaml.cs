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
        Dictionary<string, List<string>> subjects = new Dictionary<string, List<string>>();
        static List<Student> students = JsonSerializer.Deserialize<Student[]>(File.ReadAllText("Source/students.json")).ToList();
        static List<Teacher> teachers = JsonSerializer.Deserialize<Teacher[]>(File.ReadAllText("Source/teachers.json")).ToList();

        static Teacher loginName;
        static public Teacher LoginName {
            get
            {
                return loginName;
            }
            set 
            {
                loginName = value;
            } }

        public static object Students { get; internal set; }

        public MainWindow()
        {
            GetSubjects();
            InitializeComponent();
            //tb_Name.Text = students[0].Grades[0].Subject;
        }

        public void GetSubjects()
        {
            string className;
            string subject;
            foreach (Teacher teacher in teachers)
            {
                foreach(KeyValuePair<string, string> classSubject in teacher.ClassSubject)
                {
                    className = classSubject.Key;
                    subject = classSubject.Value;
                    if (!subjects.ContainsKey(className))
                    {
                        subjects.Add(className, new List<string>() { subject });
                    }
                    if(!subjects[className].Contains(subject))
                    {
                        subjects[className].Add(subject);
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
    }
}
