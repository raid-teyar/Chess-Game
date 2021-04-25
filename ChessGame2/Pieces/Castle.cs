using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChessGame2.Pieces
{
    public class Castle : Peice
    {
        

        public Castle(int colore)
        {

            switch (colore)
            {
                case 0:
                    isWhite = true;
                    Image image = new Image()
                    {
                        Source = (ImageSource)Application.Current.FindResource("WhiteCastle"),

                    };
                    this.image = image;
                    break;
                case 1:
                    isBlack = true;
                    Image image1 = new Image()
                    {
                        Source = (ImageSource)Application.Current.FindResource("BlackCastle"),
                        Name = "BlackCastle"
                    };
                    this.image = image1;
                    break;

                default:
                    break;

            }


           


        }
    }
}
