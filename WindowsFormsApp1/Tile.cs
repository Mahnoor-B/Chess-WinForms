using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Tile
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsOccupied = false; 
        public bool LegalNextMoves = false;
        public Tile(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
