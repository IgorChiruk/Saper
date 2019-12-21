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

        private Image _1mine = (Image)Application.Current.FindResource("1mine");
        private Image _2mine = (Image)Application.Current.FindResource("2mine");
        private Image _3mine = (Image)Application.Current.FindResource("3mine");
        private Image _4mine = (Image)Application.Current.FindResource("4mine");
        private Image _5mine = (Image)Application.Current.FindResource("5mine");
        private Image _6mine = (Image)Application.Current.FindResource("6mine");
        private Image _7mine = (Image)Application.Current.FindResource("7mine");
        private Image _8mine = (Image)Application.Current.FindResource("8mine");
        private Image _9mine = (Image)Application.Current.FindResource("9mine");
        private Image noMine = (Image)Application.Current.FindResource("noMine");
        private Image mine = (Image)Application.Current.FindResource("mine");
        private Image opened_field = (Image)Application.Current.FindResource("opened_field");
        private Image explode = (Image)Application.Current.FindResource("explode");
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
            this.PreviewMouseLeftButtonUp += Field_MouseLeftButtonUp;
            this.MouseRightButtonUp += Field_MouseRightButtonUp;
            this.Content = noMine;

        }
      

        private void Field_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mine_field.x = this.x;
            mine_field.y = this.y;
        }

        private void Field_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Mark();
            this.Update();
            mine_field.x = this.x;
            mine_field.y = this.y;
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

        public void SetMine()
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

        public void setNOM()
        {
            number_of_mines_arroind++;
        }

        public void openField()
        {
            open = true;
        }

        public void setNumber(int a)
        {
            number_of_mines_arroind = a;
        }

        public bool isEmpty()
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

        public void Update()
        {
            if (!open & !isMarked) { this.Content = noMine; }
            if (!open & isMarked) { this.Content = mine; }
            if (open & isMine) { this.Content = explode; }
            if (open & !isMine)
            {
                if (number_of_mines_arroind == 0) { this.Content = opened_field; this.IsEnabled = false; }
                else
                {
                    switch (number_of_mines_arroind)
                    {
                        case 1:
                            {
                                this.Content = _1mine;
                                break;
                            }

                        case 2:
                            {
                                this.Content = _2mine;
                                break;
                            }

                        case 3:
                            {
                                this.Content = _3mine;
                                break;
                            }

                        case 4:
                            {
                                this.Content = _4mine;
                                break;
                            }

                        case 5:
                            {
                                this.Content = _5mine;
                                break;
                            }

                        case 6:
                            {
                                this.Content = _6mine;
                                break;
                            }

                        case 7:
                            {
                                this.Content = _7mine;
                                break;
                            }

                        case 8:
                            {
                                this.Content = _8mine;
                                break;
                            }

                    }
                }
            }
        }

        //public void Update()
        //{
        //    if (isMine) { this.Content = mine; }
        //    if (!isMine)
        //    {
        //        switch (number_of_mines_arroind)
        //        {
        //            case 0:
        //                {
        //                    this.Content = noMine;
        //                    break;
        //                }

        //            case 1:
        //                {
        //                    this.Content = _1mine;
        //                    break;
        //                }

        //            case 2:
        //                {
        //                    this.Content = _2mine;
        //                    break;
        //                }

        //            case 3:
        //                {
        //                    this.Content = _3mine;
        //                    break;
        //                }

        //            case 4:
        //                {
        //                    this.Content = _4mine;
        //                    break;
        //                }

        //            case 5:
        //                {
        //                    this.Content = _5mine;
        //                    break;
        //                }

        //            case 6:
        //                {
        //                    this.Content = _6mine;
        //                    break;
        //                }

        //            case 7:
        //                {
        //                    this.Content = _7mine;
        //                    break;
        //                }

        //            case 8:
        //                {
        //                    this.Content = _8mine;
        //                    break;
        //                }
        //        }
        //    }
            

        }
    }




    

