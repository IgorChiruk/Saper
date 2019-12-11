using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Saper
{
    class field : Button
    {

        private int x, y, number_of_mines_arroind;
        private bool isMine, open, isMarked;

        private Brush _1mine = (Brush)Application.Current.FindResource("1mine");
        private Brush _2mine = (Brush)Application.Current.FindResource("2mine");
        private Brush _3mine = (Brush)Application.Current.FindResource("3mine");
        private Brush _4mine = (Brush)Application.Current.FindResource("4mine");
        private Brush _5mine = (Brush)Application.Current.FindResource("5mine");
        private Brush _6mine = (Brush)Application.Current.FindResource("6mine");
        private Brush _7mine = (Brush)Application.Current.FindResource("7mine");
        private Brush _8mine = (Brush)Application.Current.FindResource("8mine");
        private Brush _9mine = (Brush)Application.Current.FindResource("9mine");

        private Brush noMine = (Brush)Application.Current.FindResource("noMine");
        private Brush mine = (Brush)Application.Current.FindResource("mine");

        public field()
        {
            x = 0;
            y = 0;
            number_of_mines_arroind = 0;
            isMine = false; //является ли поле миной
            open = false; //открыта клетка или нет
            isMarked = false; //помечена ли поле миной
            this.Height = 25;
            this.Width = 25;
            this.Click += Field_Click;
            this.MouseRightButtonUp += Field_MouseRightButtonUp;
            this.Background = noMine;
        }

        private void Field_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isMarked) { this.Background = noMine; }
            else { this.Background = mine; }
            this.Mark();
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public bool IsMine()
        {
            return isMine;
        }

        void SetMine()
        {
            isMine = true;
        }

        public bool isOpened()
        {
            return open;
        }


        public int GetNOM()
        {
            return number_of_mines_arroind;
        }

        void setNOM()
        {
            number_of_mines_arroind++;
        }

        void openField()
        {
            open = true;
        }

        void setNumber(int a)
        {
            number_of_mines_arroind = a;
        }

        bool isEmpty()
        {
            return ((number_of_mines_arroind == 0) && (!isMine));
        }

        public void SetPosition(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        private void Mark()
        {
            if (isMarked) { this.isMarked = false; }
            else { this.isMarked = true; }
            
        }
        public bool IsMarked()
        {
            return isMarked;
        }
    }

}


    

