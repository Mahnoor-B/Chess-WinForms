using System;

using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static Board chessBoard = new Board(8);
        public Moves move = new Moves();
        public Button[,] tileBtn = new Button[chessBoard.Size, chessBoard.Size];
        public Button[,] tileBox = new Button[chessBoard.Size, chessBoard.Size];
        Button newSender, currentClickedButton;
        public Tile currentTile;
        public String piece;
        Point newLocation;
        public int x, y, row, column, player = 1;
        char[,] allPieces = new char[8, 8] {
          { 'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' },
          {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' },
          {'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e',},
          { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e',},
          { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e',},
          { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e'},
          { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
          { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'}
      };
public Form1()
        {
            InitializeComponent();
            allPieces = new char[8, 8] {
          { 'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' },
          {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' },
          {'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e',},
          { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e',},
          { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e',},
          { 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e'},
          { 'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
          { 'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'}
      };
            GenerateTiles();
        }
        public void GenerateTiles()
        {
            int buttonSize = panel1.Width/chessBoard.Size;
            panel1.Height = panel1.Width;

            for(int i=0; i<chessBoard.Size; i++)
            {
                for(int j=0; j<chessBoard.Size; j++)
                {
                    var clr1 = Color.DarkGray;
                    var clr2 = Color.White;
                    tileBox[i, j] = new Button();
                    tileBox[i, j].Width = buttonSize;
                    tileBox[i, j].Height = buttonSize;

                    tileBtn[i, j] = new Button();
                    tileBtn[i, j].Width = buttonSize/2;
                    tileBtn[i, j].Height = buttonSize/2;

                    if (i % 2 == 0)
                        tileBox[i,j].BackColor = j % 2 != 0 ? clr1 : clr2;
                    else
                        tileBox[i,j].BackColor = j % 2 != 0 ? clr2 : clr1;

                    tileBox[i, j].Location = new Point(i * buttonSize, j * buttonSize); 
                    tileBtn[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    tileBtn[i, j].Text = "" + allPieces[j,i];
                    tileBtn[i, j].Tag = new Point(i, j);
                    tileBtn[i, j].Click += Piece_Clicked;

                    panel1.Controls.Add(tileBtn[i, j]);
                    panel1.Controls.Add(tileBox[i, j]);

                }
            }
        }
        void Piece_Clicked(Object sender, EventArgs e)
        {  
            if (currentClickedButton == null)
            {
                newSender = (Button)sender ;
                newLocation = (Point)newSender.Tag;

                row = newLocation.Y;
                column = newLocation.X;

                if (newSender.Text.Any(char.IsUpper) && player != 1)
                {
                    return;
                }

                if (newSender.Text.Any(char.IsLower) && player != 2)
                {
                    return;
                }
                currentClickedButton = (Button)sender;
                Point location = (Point)currentClickedButton.Tag;
                piece = (String)currentClickedButton.Text;
                
                x = location.X;
                y = location.Y;

                currentTile = chessBoard.tileGrid[location.X, location.Y];
                move.ShowPaths(piece, player, chessBoard, x,y, tileBtn, currentTile);
            }
            else
            {
                Button newButton = (Button)sender;
                String temp = currentClickedButton.Text;
                Point newTileLocation = (Point)newButton.Tag;

                if ((currentClickedButton.Text.Any(char.IsUpper) && player != 2 && !newButton.Text.Equals("e")))
                {
                    if (SamePlayer())
                    {
                        if (move.IsPathClear(newTileLocation.X, newTileLocation.Y, x, y, piece, player, tileBtn, currentClickedButton, currentTile,chessBoard))
                        {
                            currentClickedButton.Text = "e";
                            currentTile = null;
                            currentClickedButton = null;
                            move.RemoveHighlights(chessBoard, tileBtn);
                            move.ActivateButtons(chessBoard, tileBtn);
                            SwitchPlayers();
                        }

                    }

                    return;
                }
                else if (currentClickedButton.Text.Any(char.IsLower) && player != 1 && !newButton.Text.Equals("e"))
                {
                    if (SamePlayer())
                    {

                        if (move.IsPathClear(newTileLocation.X, newTileLocation.Y, x, y, piece, player, tileBtn, currentClickedButton, currentTile, chessBoard))
                        {
                            currentClickedButton.Text = "e";
                            newButton.Text = temp;
                            currentClickedButton = null;
                            currentTile = null;


                            move.RemoveHighlights(chessBoard, tileBtn);
                            move.ActivateButtons(chessBoard, tileBtn);
                            SwitchPlayers();
                        }

                    }

                    return;
                }
                else
                {
                    if (move.IsPathClear(newTileLocation.X, newTileLocation.Y, x, y, piece, player, tileBtn, currentClickedButton, currentTile, chessBoard))
                    {

                        currentClickedButton.Text = newButton.Text;
                        newButton.Text = temp;

                        currentClickedButton = null;
                        currentTile = null;
                        move.RemoveHighlights(chessBoard, tileBtn);
                        move.ActivateButtons(chessBoard, tileBtn);

                        SwitchPlayers();
                    }
                }
            }
         
          }

        /*   void ShowPaths(String piece, int player)
           {
               switch (piece)
               {
                   case "p":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Pawn", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("Pawn");
                           break;
                       }
                   case "P":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Pawn", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("Pawn");

                           break;
                       }
                   case "r":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Rook", player);
                           HighlightLegalMoves("Rook");
                           break;
                       }
                   case "R":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Rook", player);
                           HighlightLegalMoves("Rook");
                           break;
                       }
                   case "n":
                       { 
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Knight", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("Knight");
                           break;
                       }
                   case "N":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Knight", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("Knight");
                           break;
                       }
                   case "b":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Bishop", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("Bishop");
                           break;
                       }
                   case "B":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Bishop", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("Bishop");
                           break;
                       }
                   case "q":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Queen", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("Queen");
                           break;
                       }
                   case "Q":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "Queen", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("Queen");
                           break;
                       }
                   case "k":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "King", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("King");
                           break;
                       }

                   case "K":
                       {
                           tileBtn[x, y].BackColor = Color.GreenYellow;
                           chessBoard.NextLegalMoves(currentTile, "King", player);
                           DeActivateOtherButtons();
                           HighlightLegalMoves("King");
                           break;
                       }

               }

           }
           void HighlightLegalMoves(String text)
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

           void RemoveHighlights()
           {
               for (int i = 0; i < chessBoard.Size; i++)
               {
                   for (int j = 0; j < chessBoard.Size; j++)
                   {
                           tileBtn[i, j].BackColor = default(Color);
                           chessBoard.tileGrid[i,j].LegalNextMoves = false;
                   }
               }
           }*/



        /*  void ActivateButtons()
          {
              for (int i = 0; i < chessBoard.Size; i++)
              {
                  for (int j = 0; j < chessBoard.Size; j++)
                  {
                      tileBtn[i, j].Enabled = true;
                  }
              }
          }*/
        /* void SwitchPlayers()
         {
             if (player == 1)
                 player = 2;
             else
                 player = 1;
         }
       */
        /*  bool IsPathClear(int destRow, int destColumn, int srcX, int srcY, String piece, int player)
         {
             switch (piece)
             {
                 case "p":
                     {
                         if (!tileBtn[srcX, srcY + 1].Text.Equals("e"))
                         {
                             currentClickedButton = null;
                             move.RemoveHighlights(chessBoard, tileBtn);
                             ActivateButtons();
                             return false;
                         }



                         break;
                     }
                 case "P":
                     {
                         if (!tileBtn[srcX, srcY - 1].Text.Equals("e"))
                         {
                             currentClickedButton = null;
                             move.RemoveHighlights(chessBoard, tileBtn);
                             ActivateButtons();
                             return false; 
                         }


                         break;
                     }
                 case "q":
                     {
                         //bottom right diagonal
                         if(destRow > srcX )
                         {
                             for (int x = srcX; x < destRow; x++ )
                             {
                                 if(destColumn > srcY)
                                 {
                                     for (int y = srcY; y< destColumn; y++)
                                     {
                                         if (!tileBtn[x, y].Text.Equals("e"))
                                         {
                                             currentClickedButton = null;
                                             currentTile = null;
                                             move.RemoveHighlights(chessBoard, tileBtn);
                                             ActivateButtons();
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
                                             move.RemoveHighlights(chessBoard, tileBtn);
                                             ActivateButtons();
                                             return false;
                                         }

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
                                             move.RemoveHighlights(chessBoard, tileBtn);
                                             ActivateButtons();
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
                             for (int x = srcX -1 ; x > destRow; x--)
                             {
                                 if (destColumn < srcY)
                                 {
                                     for (int y = srcY - 1; y >= destColumn; y--)
                                     {
                                         if (!tileBtn[x, y].Text.Equals("e"))
                                         {
                                             currentClickedButton = null;
                                             currentTile = null;
                                             move.RemoveHighlights(chessBoard, tileBtn);
                                             ActivateButtons();
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
                                         move.RemoveHighlights(chessBoard, tileBtn);
                                         ActivateButtons();
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
                                         move.RemoveHighlights(chessBoard, tileBtn);
                                         ActivateButtons();
                                         return false;
                                     }

                                 }
                             }
                         }
                         //same row diff column
                         if (destColumn == srcY)
                         {
                             if (destRow< srcX)
                             {
                                 for (int x = srcX - 1; x >= destRow; x--)
                                 {
                                     if (!tileBtn[x, srcY].Text.Equals("e"))
                                     {
                                         currentClickedButton = null;
                                         currentTile = null;
                                         move.RemoveHighlights(chessBoard, tileBtn);
                                         ActivateButtons();
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
                                         move.RemoveHighlights(chessBoard, tileBtn);
                                         ActivateButtons();
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
                             move.RemoveHighlights(chessBoard, tileBtn);
                             ActivateButtons();
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
                             move.RemoveHighlights(chessBoard, tileBtn);
                             ActivateButtons();
                             return false;
                         }
                         break;
                     }
                 case "r":
                     {
                         if (destRow >= srcX)
                         {
                             for (int x = srcX; x <= destRow; x++)
                             {
                                 if (!tileBtn[x, srcY].Text.Equals("e"))
                                 {
                                     currentClickedButton = null;
                                     move.RemoveHighlights(chessBoard, tileBtn);
                                     ActivateButtons();
                                     return false;
                                 }
                                 else
                                     return true;
                                 }

                             }
                         break;
                     }
                 case "R":
                     {
                         if (destRow >= srcX)
                         {
                             for (int x = srcX; x <= destRow; x++)
                             {
                                 if (!tileBtn[x, srcY].Text.Equals("e"))
                                 {
                                     currentClickedButton = null;
                                     move.RemoveHighlights(chessBoard, tileBtn);
                                     ActivateButtons();
                                     return false;
                                 }
                                 else
                                     return true;
                             }

                         }
                         break;
                     }
                 case "b":
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
                                             move.RemoveHighlights(chessBoard, tileBtn);
                                             ActivateButtons();
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
                                             move.RemoveHighlights(chessBoard, tileBtn);
                                             ActivateButtons();
                                             return false;
                                         }

                                     }
                                 }

                             }
                         }

                         break;
                     }
                 case "B":
                     {
                         if (destRow > srcX)
                         {
                             for (int x = srcX; x < destRow; x++)
                             {
                                 if (destColumn < srcY)
                                 {
                                     for (int y = srcY; y > destColumn; y--)
                                     {
                                         if (!tileBtn[x, y].Text.Equals("e"))
                                         {
                                             currentClickedButton = null;
                                             move.RemoveHighlights(chessBoard, tileBtn);
                                             ActivateButtons();
                                             return false;
                                         }
                                         else
                                             return true;
                                     }
                                 }

                             }
                         }

                         //top left
                         if (destRow < srcX)
                         {
                             for (int x = srcX; x > destRow; x--)
                             {
                                 if (destColumn < srcY)
                                 {
                                     for (int y = srcY; y >= destColumn; y--)
                                     {
                                         if (!tileBtn[x, y].Text.Equals("e"))
                                         {
                                             currentClickedButton = null;
                                             move.RemoveHighlights(chessBoard, tileBtn);
                                             ActivateButtons();
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
         }*/

        public void SwitchPlayers()
        {
            if (player == 1)
                player = 2;
            else
                player = 1;
        }
        bool SamePlayer()
        {
            if (currentClickedButton.Text.Any(char.IsLower))
            {
                currentClickedButton = null;
                currentTile = null;
                move.RemoveHighlights(chessBoard, tileBtn);
                move.ActivateButtons(chessBoard, tileBtn);
                return false;
            }

            if (currentClickedButton.Text.Any(char.IsUpper))
            {
                currentClickedButton = null;
                currentTile = null;
                move.RemoveHighlights(chessBoard, tileBtn);
                move.ActivateButtons(chessBoard, tileBtn);
                return false;
            }
            return true;
        }

    }
}
