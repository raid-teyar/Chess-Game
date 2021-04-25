using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Interop;
using System.Windows.Shapes;

namespace ChessGame2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {

            InitializeComponent();

            ChessGame2.ChessBoard.CreatTable(ChessBoard);
            ChessBoard chessBoard = new ChessBoard(PiecesBoard);

        }
        private int Count = 0;
        private bool isCaptured = false;
        private Pieces.Peice piecePressed;
        private void ChessBoard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Count++;


            if (Count == 1 && !isCaptured)
            {
                piecePressed = ChessGame2.ChessBoard.PeicePressed(ChessGame2.ChessBoard.CellPresed(e, canvas));

                isCaptured = true;

            }
            else if (Count == 2)
            {
                Pieces.Peice peiceWasThere = ChessGame2.ChessBoard.PeicePressed(ChessGame2.ChessBoard.CellPresed(e, canvas));
                if (peiceWasThere != null)
                {
                    if (ChessGame2.ChessBoard.CellPresed(e, canvas).X == peiceWasThere.position.X && ChessGame2.ChessBoard.CellPresed(e, canvas).Y == peiceWasThere.position.Y)
                    {
                        PiecesBoard.Children.Remove(peiceWasThere.image);
                        peiceWasThere.position.X = 999;
                        peiceWasThere.position.Y = 999;
                        DisplayText.Text = peiceWasThere.image.Name + " removed";
                    }
                }


                Grid.SetColumn(piecePressed.image, (int)ChessGame2.ChessBoard.CellPresed(e, canvas).X);
                Grid.SetRow(piecePressed.image, (int)ChessGame2.ChessBoard.CellPresed(e, canvas).Y);
                piecePressed.position.X = (int)ChessGame2.ChessBoard.CellPresed(e, canvas).X;
                piecePressed.position.Y = (int)ChessGame2.ChessBoard.CellPresed(e, canvas).Y;
                Count = 0;
                isCaptured = false;

               

            }
        }





    }
}
