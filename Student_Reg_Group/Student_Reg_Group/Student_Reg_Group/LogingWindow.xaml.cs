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

namespace Student_Reg_Group
{
    /// <summary>
    /// Interaction logic for LogingWindow.xaml
    /// </summary>
    public partial class LogingWindow : Window
    {
        public LogingWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            normalUserLoging normalUserLoging = new normalUserLoging();
            normalUserLoging.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminLogingWindow AdminLogingWindow = new AdminLogingWindow();
            AdminLogingWindow.Show();
        }
    }
}
