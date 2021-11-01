using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Moves
    {
        public void ShowPaths(String piece, int player, Board chessBoard, int x,int y, Button[,] tileBtn, Tile currentTile)
        {
            switch (piece)
            {
                case "p":
                    {
                        tileBtn[x,y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Pawn", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Pawn", chessBoard, tileBtn);
                        break;
                    }
                case "P":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Pawn", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Pawn", chessBoard, tileBtn);

                        break;
                    }
                case "r":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Rook", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Rook", chessBoard, tileBtn);
                        break;
                    }
                case "R":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Rook", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Rook", chessBoard, tileBtn);
                        break;
                    }
                case "n":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Knight", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Knight", chessBoard, tileBtn);
                        break;
                    }
                case "N":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Knight", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Knight", chessBoard, tileBtn);
                        break;
                    }
                case "b":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Bishop", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Bishop", chessBoard, tileBtn);
                        break;
                    }
                case "B":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Bishop", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Bishop", chessBoard, tileBtn);
                        break;
                    }
                case "q":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Queen", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Queen", chessBoard, tileBtn);
                        break;
                    }
                case "Q":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "Queen", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("Queen", chessBoard, tileBtn);
                        break;
                    }
                case "k":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "King", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("King", chessBoard, tileBtn);
                        break;
                    }

                case "K":
                    {
                        tileBtn[x, y].BackColor = Color.GreenYellow;
                        chessBoard.NextLegalMoves(currentTile, "King", player);
                        DeActivateOtherButtons(chessBoard, tileBtn);
                        HighlightLegalMoves("King", chessBoard, tileBtn);
                        break;
                    }

            }

        }
        public void HighlightLegalMoves(String text, Board chessBoard, Button[,] tileBtn)
        {
            for (int i = 0; i < chessBoard.Size; i++)
            {
                for (int j = 0; j < chessBoard.Size; j++)
                {
                    if (chessBoard.tileGrid[i, j].LegalNextMoves == true)
                    {
                        tileBtn[i, j].BackColor = Color.GreenYellow;
                        tileBtn[i, j].Enabled = true;
                    }
                }
            }
        }

        public void RemoveHighlights(Board chessBoard, Button[,] tileBtn)
        {
            for (int i = 0; i < chessBoard.Size; i++)
            {
                for (int j = 0; j < chessBoard.Size; j++)
                {
                    tileBtn[i, j].BackColor = default(Color);
                    chessBoard.tileGrid[i, j].LegalNextMoves = false;
                }
            }
        }

        public void DeActivateOtherButtons(Board chessBoard, Button[,] tileBtn)
        {
            for (int i = 0; i < chessBoard.Size; i++)
            {
                for (int j = 0; j < chessBoard.Size; j++)
                {
                    tileBtn[i, j].Enabled = false;
                }
            }
        }

        public void ActivateButtons(Board chessBoard, Button[,] tileBtn)
        {
            for (int i = 0; i < chessBoard.Size; i++)
            {
                for (int j = 0; j < chessBoard.Size; j++)
                {
                    tileBtn[i, j].Enabled = true;
                }
            }
        }

        public bool IsPathClear(int destRow, int destColumn, int srcX, int srcY, String piece, int player, Button[,] tileBtn, Button currentClickedButton, Tile currentTile, Board chessBoard)
        {
            switch (piece)
            {
                case "p":
                    {
                        if (!tileBtn[srcX, srcY + 1].Text.Equals("e"))
                        {
                            currentClickedButton = null;
                            RemoveHighlights(chessBoard, tileBtn);
                            ActivateButtons(chessBoard, tileBtn);
                            return false;
                        }



                        break;
                    }
                case "P":
                    {
                        if (!tileBtn[srcX, srcY - 1].Text.Equals("e"))
                        {
                            currentClickedButton = null;
                            RemoveHighlights(chessBoard, tileBtn);
                            ActivateButtons(chessBoard, tileBtn);
                            return false;
                        }


                        break;
                    }
                case "q":
                    {
                        //bottom right diagonal
                        if (destRow > srcX)
                        {
                            for (int x = srcX; x < destRow; x++)
                            {
                                if (destColumn > srcY)
                                {
                                    for (int y = srcY; y < destColumn; y++)
                                    {
                                        if (!tileBtn[x, y].Text.Equals("e"))
                                        {
                                            currentClickedButton = null;
                                            currentTile = null;
                                            RemoveHighlights(chessBoard, tileBtn);
                                            ActivateButtons(chessBoard, tileBtn);
                                            return false;
                                        }
                                        else
                                            return true;
                                    }
                                }

                            }
                        }

                        //bottom left diagonal
                        if (destRow < srcX)
                        {
                            for (int x = srcX; x < destRow; x--)
                            {
                                if (destColumn > srcY)
                                {
                                    for (int y = srcY; y > destColumn; y++)
                                    {
                                        if (!tileBtn[x, y].Text.Equals("e"))
                                        {
                                            currentClickedButton = null;
                                            currentTile = null;
                                            RemoveHighlights(chessBoard, tileBtn);
                                            ActivateButtons(chessBoard, tileBtn);
                                            return false;
                                        }

                                    }
                                }

                            }
                        }
                        //same column diff row
                        if (destRow == srcX)
                        {
                            if (destColumn < srcY)
                            {
                                for (int y = srcY - 1; y >= destColumn; y--)
                                {
                                    if (!tileBtn[srcX, y].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                            else if (destColumn > srcY)
                            {
                                for (int y = srcY + 1; y <= destColumn; y++)
                                {
                                    if (!tileBtn[srcX, y].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                        }
                        //same row diff column
                        if (destColumn == srcY)
                        {
                            if (destRow < srcX)
                            {
                                for (int x = srcX - 1; x >= destRow; x--)
                                {
                                    if (!tileBtn[x, srcY].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                            else if (destRow > srcX)
                            {
                                for (int x = srcX + 1; x <= destRow; x++)
                                {
                                    if (!tileBtn[x, srcY].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                        }


                        break;
                    }
                case "Q":
                    {
                        //top right diagonal
                        if (destRow > srcX)
                        {
                            for (int x = srcX - 1; x < destRow; x++)
                            {
                                if (destColumn < srcY)
                                {
                                    for (int y = srcY - 1; y > destColumn; y--)
                                    {
                                        if (!tileBtn[x, y].Text.Equals("e"))
                                        {
                                            currentClickedButton = null;
                                            currentTile = null;
                                            RemoveHighlights(chessBoard, tileBtn);
                                            ActivateButtons(chessBoard, tileBtn);
                                            return false;
                                        }
                                        else
                                            return true;
                                    }
                                }

                            }
                        }

                        //top left diagonal
                        if (destRow < srcX)
                        {
                            for (int x = srcX - 1; x > destRow; x--)
                            {
                                if (destColumn < srcY)
                                {
                                    for (int y = srcY - 1; y >= destColumn; y--)
                                    {
                                        if (!tileBtn[x, y].Text.Equals("e"))
                                        {
                                            currentClickedButton = null;
                                            currentTile = null;
                                            RemoveHighlights(chessBoard, tileBtn);
                                            ActivateButtons(chessBoard, tileBtn);
                                            return false;
                                        }
                                        else
                                            return true;
                                    }
                                }

                            }
                        }

                        //same column diff row
                        if (destRow == srcX)
                        {
                            if (destColumn < srcY)
                            {
                                for (int y = srcY - 1; y >= destColumn; y--)
                                {
                                    if (!tileBtn[srcX, y].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                            else if (destColumn > srcY)
                            {
                                for (int y = srcY + 1; y <= destColumn; y++)
                                {
                                    if (!tileBtn[srcX, y].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                        }
                        //same row diff column
                        if (destColumn == srcY)
                        {
                            if (destRow < srcX)
                            {
                                for (int x = srcX - 1; x >= destRow; x--)
                                {
                                    if (!tileBtn[x, srcY].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                            else if (destRow > srcX)
                            {
                                for (int x = srcX + 1; x <= destRow; x++)
                                {
                                    if (!tileBtn[x, srcY].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                        }
                        break;
                    }
                case "k":
                    {
                        //top
                        if (!tileBtn[destRow, destColumn].Text.Equals("e"))
                        {
                            currentClickedButton = null;
                            currentTile = null;
                            RemoveHighlights(chessBoard, tileBtn);
                            ActivateButtons(chessBoard, tileBtn);
                            return false;
                        }

                        break;
                    }
                case "K":
                    {
                        if (!tileBtn[destRow, destColumn].Text.Equals("e"))
                        {
                            currentClickedButton = null;
                            currentTile = null;
                            RemoveHighlights(chessBoard, tileBtn);
                            ActivateButtons(chessBoard, tileBtn);
                            return false;
                        }
                        break;
                    }
                case "r":
                    {
                        //same column diff row
                        if (destRow == srcX)
                        {
                            if (destColumn < srcY)
                            {
                                for (int y = srcY - 1; y >= destColumn; y--)
                                {
                                    if (!tileBtn[srcX, y].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                            else if (destColumn > srcY)
                            {
                                for (int y = srcY + 1; y <= destColumn; y++)
                                {
                                    if (!tileBtn[srcX, y].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                        }
                        //same row diff column
                        if (destColumn == srcY)
                        {
                            if (destRow < srcX)
                            {
                                for (int x = srcX - 1; x >= destRow; x--)
                                {
                                    if (!tileBtn[x, srcY].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                            else if (destRow > srcX)
                            {
                                for (int x = srcX + 1; x <= destRow; x++)
                                {
                                    if (!tileBtn[x, srcY].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                        }
                        break;
                    }
                case "R":
                    {
                        //same column diff row
                        if (destRow == srcX)
                        {
                            if (destColumn < srcY)
                            {
                                for (int y = srcY - 1; y >= destColumn; y--)
                                {
                                    if (!tileBtn[srcX, y].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                            else if (destColumn > srcY)
                            {
                                for (int y = srcY + 1; y <= destColumn; y++)
                                {
                                    if (!tileBtn[srcX, y].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                        }
                        //same row diff column
                        if (destColumn == srcY)
                        {
                            if (destRow < srcX)
                            {
                                for (int x = srcX - 1; x >= destRow; x--)
                                {
                                    if (!tileBtn[x, srcY].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                            else if (destRow > srcX)
                            {
                                for (int x = srcX + 1; x <= destRow; x++)
                                {
                                    if (!tileBtn[x, srcY].Text.Equals("e"))
                                    {
                                        currentClickedButton = null;
                                        currentTile = null;
                                        RemoveHighlights(chessBoard, tileBtn);
                                        ActivateButtons(chessBoard, tileBtn);
                                        return false;
                                    }

                                }
                            }
                        }
                        break;
                    }
                case "b":
                    {
                        //top right diagonal
                        if (destRow > srcX)
                        {
                            for (int x = srcX - 1; x < destRow; x++)
                            {
                                if (destColumn < srcY)
                                {
                                    for (int y = srcY - 1; y > destColumn; y--)
                                    {
                                        if (!tileBtn[x, y].Text.Equals("e"))
                                        {
                                            currentClickedButton = null;
                                            currentTile = null;
                                            RemoveHighlights(chessBoard, tileBtn);
                                            ActivateButtons(chessBoard, tileBtn);
                                            return false;
                                        }
                                        else
                                            return true;
                                    }
                                }

                            }
                        }

                        //top left diagonal
                        if (destRow < srcX)
                        {
                            for (int x = srcX - 1; x > destRow; x--)
                            {
                                if (destColumn < srcY)
                                {
                                    for (int y = srcY - 1; y >= destColumn; y--)
                                    {
                                        if (!tileBtn[x, y].Text.Equals("e"))
                                        {
                                            currentClickedButton = null;
                                            currentTile = null;
                                            RemoveHighlights(chessBoard, tileBtn);
                                            ActivateButtons(chessBoard, tileBtn);
                                            return false;
                                        }
                                        else
                                            return true;
                                    }
                                }

                            }
                        }

                        break;
                    }
                case "B":
                    {
                        //top right diagonal
                        if (destRow > srcX)
                        {
                            for (int x = srcX - 1; x < destRow; x++)
                            {
                                if (destColumn < srcY)
                                {
                                    for (int y = srcY - 1; y > destColumn; y--)
                                    {
                                        if (!tileBtn[x, y].Text.Equals("e"))
                                        {
                                            currentClickedButton = null;
                                            currentTile = null;
                                            RemoveHighlights(chessBoard, tileBtn);
                                            ActivateButtons(chessBoard, tileBtn);
                                            return false;
                                        }
                                        else
                                            return true;
                                    }
                                }

                            }
                        }

                        //top left diagonal
                        if (destRow < srcX)
                        {
                            for (int x = srcX - 1; x > destRow; x--)
                            {
                                if (destColumn < srcY)
                                {
                                    for (int y = srcY - 1; y >= destColumn; y--)
                                    {
                                        if (!tileBtn[x, y].Text.Equals("e"))
                                        {
                                            currentClickedButton = null;
                                            currentTile = null;
                                            RemoveHighlights(chessBoard, tileBtn);
                                            ActivateButtons(chessBoard, tileBtn);
                                            return false;
                                        }
                                        else
                                            return true;
                                    }
                                }

                            }
                        }
                        break;
                    }
            }

            return true;
        }

    }
}
