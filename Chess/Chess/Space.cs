using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Space
    {
        private string spaceColor;
        private int spaceRank;
        private int spaceFile;
        bool hasPiece;
        public Space(string color, int rank, int file, char type, string pieceColor)
        {
            spaceColor = color;
            spaceRank = rank;
            spaceFile = file;
            if(!type.Equals(null))
            {
                Piece p = new Piece(type, pieceColor);
                hasPiece = true;
            }
            else
            {
                hasPiece = false;
            }
        }
    }
}