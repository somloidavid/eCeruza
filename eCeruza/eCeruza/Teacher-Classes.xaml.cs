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
    /// <summary>
    /// Interaction logic for Teacher_Classes.xaml
    /// </summary>
    public partial class Teacher_Classes : Window
    {
        
        public Teacher_Classes()
        {
            InitializeComponent();
            InitializeClasses();
        }

        private void InitializeClasses()
        {
            foreach (var item in MainWindow.LoginName.ClassSubject)
            {
                int lblIndex = 1;
                lblIndex++;
                Label lblName = this.FindName($"lbl{lblIndex}") as Label;
                lblName.Content = item;
            }
            

        }
    }
}
