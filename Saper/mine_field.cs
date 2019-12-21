using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

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

            this.PreviewMouseLeftButtonUp += Mine_field_MouseLeftButtonUp;
          

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
            SetMines();
            Update();
        }



        private void Mine_field_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            open(x, y);
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
            if (fields[x, y].IsMine())
            {
                //проигрыш
            }

            else if (fields[x,y].isEmpty())
            {
                if (((x - 1) >= 0) && ((y - 1) >= 0))
                {
                    open(x - 1, y - 1);
                }

                if ((x - 1) >= 0)
                {
                    open(x - 1, y);
                }
                if (((x + 1) <= row) && ((y - 1) >= 0))
                {
                    open(x + 1, y - 1);
                }
                if ((y - 1) >= 0)
                {
                    open(x, y - 1);
                }
                if ((x + 1) <= row)
                {
                    open(x + 1, y);
                }
                if (((x - 1) >= 0) && ((y + 1) <= col))
                {
                    open(x - 1, y + 1);
                }
                if ((y + 1) <= col)
                {
                    open(x, y + 1);
                }
                if (((x + 1) <= row) && ((y + 1) <= col))
                {
                    open(x + 1, y + 1);
                }
            }
            else { fields[x,y].openField(); }

            fields[_x, _y].Update();
            
        }

    }
}
