using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Saper
{
    class mine_field :Grid
    {
        public static int x,y;
        private field[,] fields;
        private int row,col,mines;

        public mine_field(int _row, int _col,int _mines)
        {
            row = _row;
            col = _col;
            mines = _mines;
            //Ширина
            this.Width = 25 * col+20;
            this.MaxWidth = 25 * col;
            this.MinWidth = 25 * col;

            //Высота
            this.Height = 25 * row+45;
            this.MaxHeight = 25 * row;
            this.MinHeight = 25 * row;

            this.MouseLeftButtonUp += Mine_field_MouseLeftButtonUp;
          

            for(int i = 0; i < col; i++)
            {
                ColumnDefinition new_col = new ColumnDefinition();
                this.ColumnDefinitions.Add(new_col);
            }

            for (int i = 0; i < row; i++)
            {
                RowDefinition new_row = new RowDefinition();
                this.RowDefinitions.Add(new_row);
            }

            fields = new field[row,col];
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    fields[i,j] = new field();             
                    fields[i,j].Margin = new Thickness(0, 0, 0, 0);
                    fields[i, j].SetPosition(i, j);
                }
               
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Grid.SetColumn(fields[i,j],j);
                    Grid.SetRow(fields[i, j], i);
                    this.Children.Add(fields[i,j]);
                }
            }

            this.AddHandler(Grid.MouseLeftButtonUpEvent, new MouseButtonEventHandler(Mine_field_MouseLeftButtonUp), true);

            SetMines();
            Update();
        }



        private void Mine_field_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(x!=-1 & y != -1) { open(x, y); }     
        }

        // Размещение мин и цифр на поле
        private void SetMines()
        {
            Random rand = new Random();
            int x,y;
            x = rand.Next(0, row - 1);
            y = rand.Next(0, col - 1);

            for (int i = 0; i < mines; i++)
            {
                while (fields[x,y].IsMine())
                {
                    x = rand.Next(0, row - 1);
                    y = rand.Next(0, col - 1);
                }

                fields[x,y].SetMine();

                if (((x - 1) >= 0) && ((y - 1) >= 0))
                    fields[x - 1,y - 1].setNOM();
                if ((x - 1) >= 0)
                    fields[x - 1,y].setNOM();
                if (((x + 1) <=row) && ((y - 1) >= 0))
                    fields[x + 1,y - 1].setNOM();
                if ((y - 1) >= 0)
                    fields[x,y - 1].setNOM();
                if ((x + 1) <=row)
                    fields[x + 1,y].setNOM();
                if (((x - 1) >= 0) && ((y + 1) <= col))
                    fields[x - 1,y + 1].setNOM();
                if ((y + 1) <= col)
                    fields[x,y + 1].setNOM();
                if (((x + 1) <= row) && ((y + 1) <= col))
                    fields[x + 1,y + 1].setNOM();

            }

            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    if (fields[i,j].IsMine())
                        fields[i,j].setNumber(0);
                }
        }

        //Обновление поля
        private void Update()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    fields[i, j].Update();
                }

            }
        }

        private void open(int _x, int _y)
        {        
            if (fields[_x, _y].IsMine())
            {

                for (int i = 0; i < row; i++)
                    for (int j = 0; j < col; j++)
                    {
                        fields[i, j].Show();
                    }
                //проигрыш
                Lose_window window = new Lose_window();
                window.Owner = App.Current.MainWindow;
                window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                window.ShowDialog();                         
            }

            else if (fields[_x,_y].isEmpty())
            {
                fields[_x, _y].openField();

                if (((_x - 1) >= 0) && ((_y - 1) >= 0))
                {
                    if (!fields[_x-1, _y-1].isOpened())
                    { open(_x - 1, _y - 1); }
                }

                if ((_x - 1) >= 0)
                {
                    if (!fields[_x - 1, _y].isOpened())
                    { open(_x - 1, _y); }
                }

                if (((_x + 1) < row) && ((_y - 1) >= 0))
                {
                    if (!fields[_x+1, _y-1].isOpened())
                    { open(_x + 1, _y - 1); }
                }

                if ((_y - 1) >= 0)
                {
                    if (!fields[_x, _y - 1].isOpened())
                    { open(_x, _y - 1); }
                }

                if ((_x + 1) < row)
                {
                    if (!fields[_x + 1, _y].isOpened())
                    { open(_x + 1, _y); }
                }

                if (((_x - 1) >= 0) && ((_y + 1) < col))
                {
                    if (!fields[_x - 1, _y + 1].isOpened())
                    { open(_x - 1, _y + 1); }
                }

                if ((_y + 1) < col)
                {
                    if (!fields[_x, _y + 1].isOpened())
                    { open(_x, _y + 1); }
                }

                if (((_x + 1) < row) && ((_y + 1) < col))
                {
                    if (!fields[_x + 1, _y + 1].isOpened())
                    { open(_x + 1, _y + 1); }
                }
            }
            else { fields[_x,_y].openField(); }

            fields[_x, _y].Update();
            Win();
        }


        //выйгрыш
        private void Win()
        {
            int count=0;
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    if (!fields[i, j].isOpened())
                    {
                        count++;
                    }                       
                }
            if (count == this.mines)
            {
                Win_window window = new Win_window();
                window.Owner = App.Current.MainWindow;
                window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                window.ShowDialog();
            }
        }

    }
}
