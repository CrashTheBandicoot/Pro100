using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Piece
    {
        private TypeOfPiece pieceType;
        private string pieceColor;
        public Piece(char type, string color)
        {
            pieceColor = color;
            switch (type)
            {
                case 'K':
                    pieceType = TypeOfPiece.King;
                    break;
                case 'Q':
                    pieceType = TypeOfPiece.Queen;
                    break;
                case 'B':
                    pieceType = TypeOfPiece.Bishop;
                    break;
                case 'N':
                    pieceType = TypeOfPiece.Knight;
                    break;
                case 'R':
                    pieceType = TypeOfPiece.Rook;
                    break;
                case 'P':
                    pieceType = TypeOfPiece.Pawn;
                    break;
            }
        }
        public string GetPieceType()
        {
            return pieceType.ToString();
        }
        public string GetColor()
        {
            return pieceColor;
        }
    }
    public enum TypeOfPiece { King, Queen, Bishop, Knight, Rook, Pawn }
}