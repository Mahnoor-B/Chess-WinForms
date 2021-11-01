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
        public Player p = new Player();
        public Button[,] tileBtn = new Button[chessBoard.Size, chessBoard.Size];
        public Button[,] tileBox = new Button[chessBoard.Size, chessBoard.Size];
        Button newSender, currentClickedButton, newButton ;
        public Tile currentTile;
        public String piece, temp;
        Point newLocation;
        public int x, y, row, column, player = 1;
        char[,] allPieces = new char[8, 8];
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
                newButton = (Button)sender;
                temp = currentClickedButton.Text;
                Point newTileLocation = (Point)newButton.Tag;

                if ((currentClickedButton.Text.Any(char.IsUpper) && player != 2 && !newButton.Text.Equals("e")))
                {
                    if (!p.SamePlayer(currentClickedButton, chessBoard, tileBtn))
                    {
                        if (piece.Equals("P"))
                        {
                            currentClickedButton.Text = "e";
                            newButton.Text = temp;
                            currentClickedButton = null;
                            currentTile = null;


                            move.RemoveHighlights(chessBoard, tileBtn);
                            move.ActivateButtons(chessBoard, tileBtn);
                            p.SwitchPlayers(ref player);
                        }
                        else if (move.IsPathClear(newTileLocation.X, newTileLocation.Y, x, y, piece, player, tileBtn, currentClickedButton, currentTile, chessBoard))
                        {
                            currentClickedButton.Text = "e";
                            newButton.Text = temp;
                            currentClickedButton = null;
                            currentTile = null;


                            move.RemoveHighlights(chessBoard, tileBtn);
                            move.ActivateButtons(chessBoard, tileBtn);
                            p.SwitchPlayers(ref player);
                        }

                    }

                    return;
                }
                else if (currentClickedButton.Text.Any(char.IsLower) && player != 1 && !newButton.Text.Equals("e"))
                {
                    if (!p.SamePlayer(currentClickedButton, chessBoard, tileBtn))
                    {
                        if (piece.Equals("p"))
                        {
                            if(!tileBtn[newTileLocation.X, newTileLocation.Y].Text.Equals("e"))
                            {
                                if (tileBtn[newTileLocation.X, newTileLocation.Y].Text.Equals("k"))
                                    move.DeActivateOtherButtons(chessBoard, tileBtn);
                                else 
                                    CapturePiece();
                            }
                           else
                                CapturePiece();
                        }
                        else if (move.IsPathClear(newTileLocation.X, newTileLocation.Y, x, y, piece, player, tileBtn, currentClickedButton, currentTile, chessBoard))
                        {
                            if (!tileBtn[newTileLocation.X, newTileLocation.Y].Text.Equals("e"))
                            {
                                if (tileBtn[newTileLocation.X, newTileLocation.Y].Text.Equals("K"))
                                    move.DeActivateOtherButtons(chessBoard, tileBtn);
                                else
                                    CapturePiece();
                            }
                            else
                                CapturePiece();
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

                        p.SwitchPlayers(ref player);
                    }
                }
            }
         
          }
       public void CapturePiece()
        {
            currentClickedButton.Text = "e";
            newButton.Text = temp;
            currentClickedButton = null;
            currentTile = null;


            move.RemoveHighlights(chessBoard, tileBtn);
            move.ActivateButtons(chessBoard, tileBtn);
            p.SwitchPlayers(ref player);
        }

    }
}
