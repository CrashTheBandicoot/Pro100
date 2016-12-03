using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Space
    {
        private string color;
        private Piece p;
        private bool hasPiece = false;
        public Space(string color)
        {
            this.color = color;
        }
        public Piece GetPiece()
        {
            return p;
        }
        public void AddPiece(char pieceType, char pieceColor)
        {
            p = new Piece(pieceType, pieceColor);
            hasPiece = true;
        }
        public void RemovePiece()
        {
            p = null;
            hasPiece = false;
        }
        public bool HasPiece()
        {
            return hasPiece;
        }
    }
}