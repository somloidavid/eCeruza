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
    /// Interaction logic for GhostGrade.xaml
    /// </summary>
    public partial class GhostGrade : Window
    {
        public GhostGrade()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            CreateGrade(int.Parse(button.Content.ToString()));
        }

        private void CreateGrade(int grade)
        {
            RowDefinition rd = new();
            rd.Height = new GridLength(50);
            Grid grd_Grade = new();
            Label lbl_Value = new();
            Label lbl_Message = new();
            Border border = new Border();
            grd_Grade.Height = 50;
            grd_Grade.Width = 600;
            grd_Grade.Margin = new Thickness(0, 5, 0, 0);
            border.CornerRadius = new CornerRadius(10);
            border.Background = StudentGrades.grey;
            lbl_Value.Foreground = StudentGrades.yellow;
            lbl_Message.Foreground = StudentGrades.yellow;
            lbl_Value.FontSize = 24;
            lbl_Message.FontSize = 24;
            lbl_Value.Content = grade;
            lbl_Message.Content = "Szellemjegy";
            lbl_Value.Width = 50;
            lbl_Message.Width = 300;
            lbl_Value.Height = 50;
            lbl_Message.Height = 50;
            lbl_Value.Margin = new Thickness(0, 0, 150, 0);
            grd_Grade.Children.Add(border);
            grd_Grade.Children.Add(lbl_Value);
            grd_Grade.Children.Add(lbl_Message);
            grd_GhostGrades.RowDefinitions.Add(rd);
            Grid.SetRow(grd_Grade, grd_GhostGrades.RowDefinitions.Count + 1);
            grd_GhostGrades.Children.Add(grd_Grade);
        }
    }
}
