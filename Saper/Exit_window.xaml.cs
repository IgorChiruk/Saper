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

namespace Saper
{
    /// <summary>
    /// Логика взаимодействия для Exit_window.xaml
    /// </summary>
    public partial class Exit_window : Window
    {
        public Exit_window()
        {
            InitializeComponent();
        }

        private void button_yes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
