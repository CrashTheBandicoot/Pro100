using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Piece
    {
        private TypeOfPiece pieceType;
        private string pieceColor;
        public Piece(char type, char color)
        {
            switch (color)
            {
                case 'l':
                    pieceColor = "Light";
                    break;
                case 'd':
                    pieceColor = "Dark";
                    break;
            }
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
        public void Move(TypeOfPiece type)
        {
            switch (type)
            {
                case TypeOfPiece.King:
                    moveKing();
                    break;
                case TypeOfPiece.Queen:
                    moveQueen();
                    break;
                case TypeOfPiece.Bishop:
                    moveBishop();
                    break;
                case TypeOfPiece.Knight:
                    moveKnight();
                    break;
                case TypeOfPiece.Rook:
                    moveRook();
                    break;
                case TypeOfPiece.Pawn:
                    movePawn();
                    break;
            }
        }
        private void moveKing()
        {

        }
        private void moveQueen()
        {

        }
        private void moveBishop()
        {

        }
        private void moveKnight()
        {

        }
        private void moveRook()
        {

        }
        private void movePawn()
        {

        }
    }
    public enum TypeOfPiece { King, Queen, Bishop, Knight, Rook, Pawn }
}