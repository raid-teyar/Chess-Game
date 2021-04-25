using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessGame2.Pieces
{
    public class Peice
    {
        public bool isWhite = false;
        public bool isBlack = false;
        public Point position = default;
        public Image image = new Image();
        public string name;
        
        
        

        public void PlacePeice(int x,int y, Grid control)
        {
            position.X = x;
            position.Y = y;
            Grid.SetColumn(image, x);
            Grid.SetRow(image, y);
            control.Children.Add(image);
        }

    }
}
