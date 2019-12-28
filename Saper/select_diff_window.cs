using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Saper
{
    class select_diff_window :Grid
    {
        public select_diff_window()
        {        
            this.Height = 300;
            this.MaxHeight = 300;
            this.MinHeight = 300;

            this.Width = 200;
            this.MaxWidth = 200;
            this.MinWidth = 200;

            //Столбцы
            for(int i = 0; i < 3; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                this.ColumnDefinitions.Add(col);
            }

            //Строки
            for (int i = 0; i < 8; i++)
            {
                RowDefinition row = new RowDefinition();
                this.RowDefinitions.Add(row);
            }

            //Label
            Label label = new Label();
            TextBlock text = new TextBlock();      
            text.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            text.Text = "Выберите сложность";
            text.FontSize = 14;

            label.Width = 200;
            label.Content = text;
            label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;

            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 1);
            Grid.SetColumnSpan(label, 3);
            this.Children.Add(label);

            //Button lite diff
            Button button_lite = new Button();
            button_lite.FontSize = 14;
            button_lite.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            button_lite.Content = "Легкая";
            button_lite.Width = 200/3;
            button_lite.Height = 30;

            button_lite.Click += Button_lite_Click;

            Grid.SetColumn(button_lite, 1);
            Grid.SetRow(button_lite, 2);
            this.Children.Add(button_lite);

            //Button mid diff
            Button button_mid = new Button();
            button_mid.FontSize = 14;
            button_mid.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            button_mid.Content = "Средняя";
            button_mid.Width = 200 / 3;
            button_mid.Height = 30;

            button_mid.Click += Button_mid_Click;

            Grid.SetColumn(button_mid, 1);
            Grid.SetRow(button_mid, 3);
            this.Children.Add(button_mid);

            //Button lite diff
            Button button_hard = new Button();
            button_hard.FontSize = 14;
            button_hard.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            button_hard.Content = "Сложная";
            button_hard.Width = 200 / 3;
            button_hard.Height = 30;

            button_hard.Click += Button_hard_Click;

            Grid.SetColumn(button_hard, 1);
            Grid.SetRow(button_hard, 4);
            this.Children.Add(button_hard);


        }

        private void Button_hard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mine_field game_field = new mine_field(25, 35 ,120);
            App.Current.MainWindow.Height = game_field.Height;
            App.Current.MainWindow.MaxHeight = game_field.Height;
            App.Current.MainWindow.MinHeight = game_field.Height;
            App.Current.MainWindow.Width = game_field.Width;
            App.Current.MainWindow.MaxWidth = game_field.Width;
            App.Current.MainWindow.MinWidth = game_field.Width;
            App.Current.MainWindow.Content = game_field;
        }   

        private void Button_mid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mine_field game_field = new mine_field(20, 20, 50);
            App.Current.MainWindow.Height = game_field.Height;
            App.Current.MainWindow.MaxHeight = game_field.Height;
            App.Current.MainWindow.MinHeight = game_field.Height;
            App.Current.MainWindow.Width = game_field.Width;
            App.Current.MainWindow.MaxWidth = game_field.Width;
            App.Current.MainWindow.MinWidth = game_field.Width;
            App.Current.MainWindow.Content = game_field;
        }

        private void Button_lite_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mine_field game_field = new mine_field(10, 10, 10);
            App.Current.MainWindow.Height = game_field.Height;
            App.Current.MainWindow.MaxHeight = game_field.Height;
            App.Current.MainWindow.MinHeight = game_field.Height;
            App.Current.MainWindow.Width = game_field.Width;
            App.Current.MainWindow.MaxWidth = game_field.Width;
            App.Current.MainWindow.MinWidth = game_field.Width;
            App.Current.MainWindow.Content = game_field;
        }
    }
}
