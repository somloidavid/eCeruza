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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eCeruza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string[]> subjects = new Dictionary<string, string[]> {
            {"9A", new string[] {"Matematika", "Irodalom", "Nyelvtan", "Testnevelés", "Történelem", "IKT Projektmunka", "Programozás", "Fizika", "Osztályfőnöki", "Digitális Kultúra", "Informatikai és Távközlési Alapok" } }    
        }; 
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
