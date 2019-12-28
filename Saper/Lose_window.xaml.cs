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
    /// Логика взаимодействия для Lose_window.xaml
    /// </summary>
    public partial class Lose_window : Window
    {
        public Lose_window()
        {
            InitializeComponent();
        }

        private void button_new_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            select_diff_window window = new select_diff_window();
            App.Current.MainWindow.Height = 300;
            App.Current.MainWindow.MaxHeight = 300;
            App.Current.MainWindow.MinHeight = 300;

            App.Current.MainWindow.Width = 200;
            App.Current.MainWindow.MaxWidth = 200;
            App.Current.MainWindow.MinWidth = 200;

            Application.Current.MainWindow.Content = window;
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
