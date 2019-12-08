using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper
{
    class field
    {

        private int x, y, number_of_mines_arroind;
        private bool isMine, open;


        public field()
        {
            x = 0;
            y = 0;
            number_of_mines_arroind = 0;
            isMine = false;
            open = false;
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

    }

}


    

