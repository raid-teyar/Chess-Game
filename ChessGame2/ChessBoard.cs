using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ChessGame2.Pieces;

namespace ChessGame2
{
    public class ChessBoard
    {


        //the list where all pieces are stored
        public static List<Peice> peices = new List<Peice>();

        



        //Placing Start Peices
        public ChessBoard(Grid panel)
        {
            //Black pawn row
            for (int i = 0; i < 8; i++)
            {
                Pawn bPawn = new Pawn(1);
                bPawn.PlacePeice(i, 1, panel);
                bPawn.image.Name = "bPawn" + i;
                peices.Add(bPawn);
            }

            //White pawn row
            for (int i = 0; i < 8; i++)
            {
                Pawn wPawn = new Pawn(0);
                wPawn.PlacePeice(i, 6, panel);
                wPawn.image.Name = "wPawn" + i;
                peices.Add(wPawn);
            }

            //Black king
            King bKing = new King(1);
            bKing.PlacePeice(3, 0, panel);
            bKing.image.Name = "bKing";
            peices.Add(bKing);

            //White King
            King wKing = new King(0);
            wKing.PlacePeice(4, 7, panel);
            wKing.image.Name = "wKing";
            peices.Add(wKing);

            //Black Queen
            Queen wQueen = new Queen(1);
            wQueen.PlacePeice(4, 0, panel);
            wQueen.image.Name = "wQueen";
            peices.Add(wQueen);
            //White Queen
            Queen bQueen = new Queen(0);
            bQueen.PlacePeice(3, 7, panel);
            bQueen.image.Name = "bQueen";
            peices.Add(bQueen);

            //Black Castles
            Castle bCactle1 = new Castle(1);
            bCactle1.PlacePeice(0, 0, panel);
            bCactle1.image.Name = "bCastle1";
            peices.Add(bCactle1);
            Castle bCactle2 = new Castle(1);
            bCactle2.PlacePeice(7, 0, panel);
            bCactle2.image.Name = "bCastle2";
            peices.Add(bCactle2);

            //White Castles
            Castle wCactle1 = new Castle(0);
            wCactle1.PlacePeice(7, 7, panel);
            wCactle1.image.Name = "wCactle1";
            peices.Add(wCactle1);

            Castle wCactle2 = new Castle(0);
            wCactle2.PlacePeice(0, 7, panel);
            wCactle2.image.Name = "wCactle2";
            peices.Add(wCactle2);


            //Black Bishops
            Bishop bBishop1 = new Bishop(1);
            bBishop1.PlacePeice(2, 0, panel);
            bBishop1.image.Name = "bBishop1";

            peices.Add(bBishop1);

            Bishop bBishop2 = new Bishop(1);
            bBishop2.PlacePeice(5, 0, panel);
            bBishop2.image.Name = "bBishop2";

            peices.Add(bBishop2);


            //White Bishops
            Bishop wBishop1 = new Bishop(0);
            wBishop1.PlacePeice(5, 7, panel);
            wBishop1.image.Name = "wBishop1";

            peices.Add(wBishop1);

            Bishop wBishop2 = new Bishop(0);
            wBishop2.PlacePeice(2, 7, panel);
            wBishop2.image.Name = "wBishop2";
            peices.Add(wBishop2);


            //Black Knights
            Knight bKnight1 = new Knight(1);
            bKnight1.PlacePeice(1, 0, panel);
            bKnight1.image.Name = "bKnight1";
            peices.Add(bKnight1);

            Knight bKnight2 = new Knight(1);
            bKnight2.PlacePeice(6, 0, panel);
            bKnight2.image.Name = "bKnight2";
            peices.Add(bKnight2);


            //White Knights
            Knight wKnight1 = new Knight(0);
            wKnight1.PlacePeice(1, 7, panel);
            wKnight1.image.Name = "wKnight1";
            peices.Add(wKnight1);

            Knight wKnight2 = new Knight(0);
            wKnight2.PlacePeice(6, 7, panel);
            wKnight2.image.Name = "wKnight2";
            peices.Add(wKnight2);
        }

        //Creating ChessBoard Table
        public static void CreatTable(Panel panel)
        {
            Style style1 = Application.Current.FindResource("1") as Style;
            Style style2 = Application.Current.FindResource("2") as Style;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bool isLight = (i + j) % 2 != 0;
                    Style cellStyle = (isLight) ? style1 : style2;
                    Label cell = new Label()
                    {
                        Style = cellStyle,
                    };

                    panel.Children.Add(cell);


                }
            }
        }

        //Gives the position of the pressed cell
        public static Point CellPresed(MouseButtonEventArgs e, IInputElement chessbord) 
        {
            const double cellSize = 75;
            Point point = e.GetPosition(chessbord);
            double x = point.X;
            double y = point.Y;
            if((x / cellSize) % 1 == 0)
            {
                x += 0.1;
            }
            if ((y/cellSize)%1 == 0)
            {
                y +=0.1;
            }
            Point cellPressed = new Point()
            {

                X = (int) (x / cellSize),
                Y = (int) (y / cellSize)
            };
            

            return cellPressed;         
        }

        public  static Peice PeicePressed(Point position) 
        {
            
            

            int x = (int)position.X;
            int y = (int)position.Y;

            foreach (Peice peice in peices)
            {
                if (x == peice.position.X && y == peice.position.Y)
                {
                     return peice;
                }
                
            }



            return null;
        }


        
        

    }
}
