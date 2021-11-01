using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Player
    {
        Moves move = new Moves();
        public void SwitchPlayers(ref int player)
        {
            if (player == 1)
                player = 2;
            else
                player = 1;
        }
        public bool SamePlayer(Button currentClickedButton, Board chessBoard, Button[,] tileBtn)
        {
            if (currentClickedButton.Text.Any(char.IsLower))
            {
                move.RemoveHighlights(chessBoard, tileBtn);
                move.ActivateButtons(chessBoard, tileBtn);
                return false;
            }

            if (currentClickedButton.Text.Any(char.IsUpper))
            {
                move.RemoveHighlights(chessBoard, tileBtn);
                move.ActivateButtons(chessBoard, tileBtn);
                return false;
            }
            return true;
        }


    }
}
