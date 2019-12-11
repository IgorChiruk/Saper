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
    /// Логика взаимодействия для game_window.xaml
    /// </summary>
    public partial class game_window : Window
    {
        public game_window()
        {
            InitializeComponent();
            this.Height = 100;
            this.Width = 100;
            mine_field game_field = new mine_field(4, 4);
           // this.Content = game_field;  
        }
    }
}
