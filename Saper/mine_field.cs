﻿using System;
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

        private field[,] fields;
        private int _row,_col;
        public mine_field(int row, int col)
        {
            _row = row;
            _col = col;
            //Ширина
            this.Width = 25 * col+20;
            this.MaxWidth = 25 * col;
            this.MinWidth = 25 * col;

            //Высота
            this.Height = 25 * row+45;
            this.MaxHeight = 25 * row;
            this.MinHeight = 25 * row;

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

        }

        private void Update()
        {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    fields[i, j].openField();
                }

            }
        }

    }
}
