
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Board
    {
        public int Size { get; set; }
        public Tile[,] tileGrid { get; set; }

        public Board(int s)
        {
            Size = s;
            tileGrid = new Tile[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    tileGrid[i, j] = new Tile(i, j);
                }
            }

        }

        public bool OutOfBounds(int row, int coloumn)
        {
            //if outside the chess board
            if (row > 7 || coloumn > 7 || row < 0 || coloumn < 0)
                return false;
            //else inside the chess board
            return true;
        }

    public void DiagonalMoves(int i, int row, int column)
        {
            if (OutOfBounds(row - 1 * i, column - 1 * i))
                tileGrid[row - 1 * i, column - 1 * i].LegalNextMoves = true;
            if (OutOfBounds(row - 1 * i, column - 1 * i))
                tileGrid[row - 1 * i, column - 1 * i].LegalNextMoves = true;

            if (OutOfBounds(row + 1 * i, column + i * 1))
                tileGrid[row + 1 * i, column + i * 1].LegalNextMoves = true;

            if (OutOfBounds(row - 1 * i, column + i * 1))
                tileGrid[row - 1 * i, column + i * 1].LegalNextMoves = true;

            if (OutOfBounds(row + 1 * i, column - i * 1))
                tileGrid[row + 1 * i, column - i * 1].LegalNextMoves = true;
        }

        void HorizontalVerticalMoves(int i, int row, int column)
        {
            //left column same row
            if (OutOfBounds(row - 1 * i, column))
                tileGrid[row - 1 * i, column].LegalNextMoves = true;

            //same column upper row
           else if (OutOfBounds(row, column - 1 * i))
                tileGrid[row, column - 1 *i].LegalNextMoves = true;

            //same column below row
            else if (OutOfBounds(row, column + 1 * i))
                tileGrid[row, column + 1 * i].LegalNextMoves = true;

            //same row right column
            else if (OutOfBounds(row + 1 * i, column))
                tileGrid[row + 1 * i, column].LegalNextMoves = true;
        }
        public void NextLegalMoves(Tile currentTile, string chessPiece, int player, Button[,] tileBtn)
        {
            switch (chessPiece)
            {
                case "Knight":
                    {
                        if (OutOfBounds(currentTile.Row - 1, currentTile.Column + 2))
                            tileGrid[currentTile.Row - 1, currentTile.Column + 2].LegalNextMoves = true;

                        if (OutOfBounds(currentTile.Row + 1, currentTile.Column + 2))
                            tileGrid[currentTile.Row + 1, currentTile.Column + 2].LegalNextMoves = true;

                        if (OutOfBounds(currentTile.Row + 1, currentTile.Column - 2))
                            tileGrid[currentTile.Row + 1, currentTile.Column - 2].LegalNextMoves = true;

                        if (OutOfBounds(currentTile.Row - 1, currentTile.Column - 2))
                            tileGrid[currentTile.Row - 1, currentTile.Column - 2].LegalNextMoves = true;

                        if (OutOfBounds(currentTile.Row - 2, currentTile.Column - 1))
                            tileGrid[currentTile.Row - 2, currentTile.Column - 1].LegalNextMoves = true;

                        if (OutOfBounds(currentTile.Row - 2, currentTile.Column + 1))
                            tileGrid[currentTile.Row - 2, currentTile.Column + 1].LegalNextMoves = true;

                        if (OutOfBounds(currentTile.Row + 2, currentTile.Column -1 ))
                            tileGrid[currentTile.Row + 2, currentTile.Column - 1].LegalNextMoves = true;

                        if (OutOfBounds(currentTile.Row + 2, currentTile.Column + 1))
                            tileGrid[currentTile.Row + 2, currentTile.Column + 1].LegalNextMoves = true;
                        break;
                    }
                        
                case "Rook":
                    {
                        for (int i = 0; i <= Size; i++)
                        {
                            for (int j = 0; j <= Size; j++)
                            {
                                HorizontalVerticalMoves(i, currentTile.Row, currentTile.Column);
                            }
                        }
                        break;
                    }
                case "King":
                    {
                            //left column same row
                            if (OutOfBounds(currentTile.Row - 1, currentTile.Column))
                                tileGrid[currentTile.Row - 1, currentTile.Column].LegalNextMoves = true;

                            //same column upper row
                            if (OutOfBounds(currentTile.Row, currentTile.Column - 1))
                                tileGrid[currentTile.Row, currentTile.Column - 1].LegalNextMoves = true;

                            //same column below row
                            if (OutOfBounds(currentTile.Row, currentTile.Column + 1))
                                tileGrid[currentTile.Row, currentTile.Column + 1].LegalNextMoves = true;

                            //same row right column
                            if (OutOfBounds(currentTile.Row + 1, currentTile.Column))
                                tileGrid[currentTile.Row + 1, currentTile.Column].LegalNextMoves = true;

                            //diagonal left down row column
                            if (OutOfBounds(currentTile.Row - 1, currentTile.Column + 1))
                                tileGrid[currentTile.Row - 1, currentTile.Column + 1].LegalNextMoves = true;

                            //diagonal right down row column
                            if (OutOfBounds(currentTile.Row + 1, currentTile.Column + 1))
                                tileGrid[currentTile.Row + 1, currentTile.Column + 1].LegalNextMoves = true;

                            //diagonal left upper row column
                            if (OutOfBounds(currentTile.Row - 1, currentTile.Column - 1))
                                tileGrid[currentTile.Row - 1, currentTile.Column - 1].LegalNextMoves = true;

                            //diagonal right upper row column
                            if (OutOfBounds(currentTile.Row + 1, currentTile.Column - 1))
                                tileGrid[currentTile.Row + 1, currentTile.Column - 1].LegalNextMoves = true;
                        break;
                    }
                case "Queen":
                    {
                        for(int i = 0; i<Size; i++)
                        {
                            for (int j=0; j<Size; j++)
                            {
                                DiagonalMoves(i, currentTile.Row, currentTile.Column);
                                HorizontalVerticalMoves(i, currentTile.Row, currentTile.Column);
                            }
                        }
                        break;
                    }
                case "Bishop":
                    {

                        for (int i = 0; i < Size; i++)
                        {
                            for (int j = 0; j < Size; j++)
                            {
                                DiagonalMoves(i, currentTile.Row, currentTile.Column);
                            }

                        }
                        break;
                    }
                case "Pawn":
                    {
                        if(player == 1)
                        {
                            if (currentTile.Column == 6)
                            {
                                tileGrid[currentTile.Row + 0, currentTile.Column - 1].LegalNextMoves = true;
                                tileGrid[currentTile.Row + 0, currentTile.Column - 2].LegalNextMoves = true;

                            }
                            else if (!tileBtn[currentTile.Row + 1, currentTile.Column - 1].Text.Equals("e"))
                            {
                                tileGrid[currentTile.Row + 1, currentTile.Column - 1].LegalNextMoves = true;
                            }
                            else if (!tileBtn[currentTile.Row - 1, currentTile.Column - 1].Text.Equals("e"))
                            {
                                tileGrid[currentTile.Row - 1, currentTile.Column - 1].LegalNextMoves = true;
                            }
                            tileGrid[currentTile.Row + 0, currentTile.Column - 1].LegalNextMoves = true;
                        }

                        else
                        {
                            if (currentTile.Column == 1)
                            {
                                tileGrid[currentTile.Row + 0, currentTile.Column + 1].LegalNextMoves = true;
                                tileGrid[currentTile.Row + 0, currentTile.Column + 2].LegalNextMoves = true;

                            }
                            else if(!tileBtn[currentTile.Row + 1, currentTile.Column + 1].Text.Equals("e"))
                            {
                                tileGrid[currentTile.Row + 1, currentTile.Column + 1].LegalNextMoves = true;
                            }
                            else if (!tileBtn[currentTile.Row - 1, currentTile.Column + 1].Text.Equals("e"))
                            {
                                tileGrid[currentTile.Row - 1, currentTile.Column + 1].LegalNextMoves = true;
                            }
                            
                            tileGrid[currentTile.Row + 0, currentTile.Column + 1].LegalNextMoves = true;
                        }                           
                        break;
                    }
            }
        }
    }
}
