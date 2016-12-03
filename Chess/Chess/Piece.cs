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
        private string pieceString = "";
        private bool HasMoved = false;
        public Piece(char type, char color)
        {
            pieceString = color.ToString() + type.ToString();
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
        public TypeOfPiece GetPieceType()
        {
            return pieceType;
        }
        public string GetColor()
        {
            return pieceColor;
        }
        public string GetPieceString()
        {
            return pieceString;
        }
        public bool Move(TypeOfPiece type, int currentRank, int currentFile, int newRank, int newFile)
        {
            bool complete = false;
            switch (type)
            {
                case TypeOfPiece.King:
                    complete = moveKing(currentRank, currentFile, newRank, newFile);
                    break;
                case TypeOfPiece.Queen:
                    complete = moveQueen(currentRank, currentFile, newRank, newFile);
                    break;
                case TypeOfPiece.Bishop:
                    complete = moveBishop(currentRank, currentFile, newRank, newFile);
                    break;
                case TypeOfPiece.Knight:
                    complete = moveKnight(currentRank, currentFile, newRank, newFile);
                    break;
                case TypeOfPiece.Rook:
                    complete = moveRook(currentRank, currentFile, newRank, newFile);
                    break;
                case TypeOfPiece.Pawn:
                    complete = movePawn(currentRank, currentFile, newRank, newFile);
                    break;
            }
            if (complete)
            {
                HasMoved = true;
            }
            return complete;
        }
        private bool moveKing(int currentRank, int currentFile, int newRank, int newFile)
        {
            for(int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2 && Board.ValidateSpace(currentRank + i, currentFile + j); j++)
                {
                    if (Board.GetBoardSpace(currentRank + i, currentFile + j).HasPiece())
                    {
                        if (Board.GetBoardSpace(currentRank + i, currentFile + j).GetPiece().GetColor() != this.GetColor())
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if(currentRank + i == newRank && currentFile + j == newFile)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool moveQueen(int currentRank, int currentFile, int newRank, int newFile)
        {
            if(moveBishop(currentRank, currentFile,newRank, newFile))
            {
                return true;
            }
            else if(moveRook(currentRank, currentFile, newRank, newFile))
            {
                return true;
            }
            return false;
        }
        private bool moveBishop(int currentRank, int currentFile, int newRank, int newFile)
        {
            //Negative X Negative Y
            bool pieceDetected = false;
            for (int i = -1; currentRank + i > 0 && currentFile + i > 0 && Board.ValidateSpace(currentRank + i, currentFile + i) && !pieceDetected; --i)
            {
                if (Board.GetBoardSpace(currentRank + i, currentFile + i).HasPiece())
                {
                    pieceDetected = true;
                    if (Board.GetBoardSpace(currentRank + i, currentFile + i).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    if (currentRank + i == newRank && currentFile + i == newFile)
                    {
                        return true;
                    }
                }
            }
            //Positive X Positive Y
            pieceDetected = false;
            for (int i = 1; currentRank + i < Board.GetBoardSize() && currentFile + i < Board.GetBoardSize() && Board.ValidateSpace(currentRank + i, currentFile + i) && !pieceDetected; ++i)
            {
                if (Board.GetBoardSpace(currentRank + i, currentFile + i).HasPiece())
                {
                    pieceDetected = true;
                    if (Board.GetBoardSpace(currentRank + i, currentFile + i ).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    if (currentRank + i == newRank && currentFile + i == newFile)
                    {
                        return true;
                    }
                }
            }
            //Negative Y Positive X
            pieceDetected = false;
            for (int i = -1; currentRank + i < Board.GetBoardSize() && currentFile - i > 0 && Board.ValidateSpace(currentRank - i, currentFile + i) && !pieceDetected; --i)
            {
                if (Board.GetBoardSpace(currentRank - i, currentFile + i).HasPiece())
                {
                    pieceDetected = true;
                    if (Board.GetBoardSpace(currentRank - i, currentFile + i).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    if (currentRank - i == newRank && currentFile + i == newFile)
                    {
                        return true;
                    }
                }
            }
            //Positive Y Negative X
            pieceDetected = false;
            for (int i = 1; currentRank - i > 0 && currentFile + i < Board.GetBoardSize() && Board.ValidateSpace(currentRank - i, currentFile + i) && !pieceDetected; ++i)
            {
                if (Board.GetBoardSpace(currentRank - i, currentFile + i).HasPiece())
                {
                    pieceDetected = true;
                    if (Board.GetBoardSpace(currentRank - i, currentFile + i).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    if (currentRank - i == newRank && currentFile + i == newFile)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool moveKnight(int currentRank, int currentFile, int newRank, int newFile)
        {
            if (currentRank + 1 == newRank && currentFile + 2 == newFile && Board.ValidateSpace(newRank, newFile))
            {
                if (Board.GetBoardSpace(newRank, newFile).HasPiece())
                {
                    if (Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (currentRank + 1 == newRank && currentFile - 2 == newFile && Board.ValidateSpace(newRank, newFile))
            {
                if (Board.GetBoardSpace(newRank, newFile).HasPiece())
                {
                    if (Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (currentRank - 1 == newRank && currentFile + 2 == newFile && Board.ValidateSpace(newRank, newFile))
            {
                if (Board.GetBoardSpace(newRank, newFile).HasPiece())
                {
                    if (Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (currentRank - 1 == newRank && currentFile - 2 == newFile && Board.ValidateSpace(newRank, newFile))
            {
                if (Board.GetBoardSpace(newRank, newFile).HasPiece())
                {
                    if (Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (currentRank + 2 == newRank && currentFile + 1 == newFile && Board.ValidateSpace(newRank, newFile))
            {
                if (Board.GetBoardSpace(newRank, newFile).HasPiece())
                {
                    if (Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (currentRank + 2 == newRank && currentFile - 1 == newFile && Board.ValidateSpace(newRank, newFile))
            {
                if (Board.GetBoardSpace(newRank, newFile).HasPiece())
                {
                    if (Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (currentRank - 2 == newRank && currentFile + 1 == newFile && Board.ValidateSpace(newRank, newFile))
            {
                if (Board.GetBoardSpace(newRank, newFile).HasPiece())
                {
                    if (Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (currentRank - 2 == newRank && currentFile - 1 == newFile && Board.ValidateSpace(newRank, newFile))
            {
                if (Board.GetBoardSpace(newRank, newFile).HasPiece())
                {
                    if (Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        private bool moveRook(int currentRank, int currentFile, int newRank, int newFile)
        {
            //negative X
            bool pieceDetected = false;
            for(int i = -1; currentRank + i >= 0 && currentFile == newFile && Board.ValidateSpace(currentRank + i, currentFile) && !Board.GetBoardSpace(currentRank + i, currentFile).HasPiece() && !pieceDetected; --i)
            {
                if (Board.GetBoardSpace(currentRank + i, currentFile).HasPiece())
                {
                    pieceDetected = true;
                    if (Board.GetBoardSpace(currentRank + i, currentFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    if (currentRank + i == newRank && currentFile == newFile)
                    {
                        return true;
                    }
                }
            }
            pieceDetected = false;
            //positive X
            for (int i = 1; currentRank + i < Board.GetBoardSize() && currentFile == newFile  && Board.ValidateSpace(currentRank + i, currentFile) && !Board.GetBoardSpace(currentRank + i, currentFile).HasPiece() && !pieceDetected; ++i)
            {
                if (Board.GetBoardSpace(currentRank + i, currentFile).HasPiece())
                {
                    pieceDetected = true;
                    if (Board.GetBoardSpace(currentRank + i, currentFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    if (currentRank + i == newRank && currentFile == newFile)
                    {
                        return true;
                    }
                }
            }
            pieceDetected = false;

            //negative Y
            for (int i = -1; currentFile + i >= 0 && currentRank == newRank && Board.ValidateSpace(currentRank, currentFile + i) && !Board.GetBoardSpace(currentRank, currentFile + i).HasPiece() && !pieceDetected; --i)
            {
                if (Board.GetBoardSpace(currentRank, currentFile + i).HasPiece())
                {
                    pieceDetected = true;
                    if (Board.GetBoardSpace(currentRank, currentFile + i).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    break;
                }
                else
                {

                    if (currentRank == newRank && currentFile + i == newFile)
                    {
                        return true;
                    }
                }
            }
            pieceDetected = false;

            //positive Y
            for (int i = 1; currentFile + i < Board.GetBoardSize() && currentRank == newRank && Board.ValidateSpace(currentRank, currentFile + i) && !Board.GetBoardSpace(currentRank, currentFile + i).HasPiece() && !pieceDetected; ++i)
            {
                if (Board.GetBoardSpace(currentRank, currentFile + i).HasPiece())
                {
                    pieceDetected = true;
                    if (Board.GetBoardSpace(currentRank, currentFile + i).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    break;
                }
                else
                {
                    if (currentRank == newRank && currentFile + i == newFile)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool movePawn(int currentRank, int currentFile, int newRank, int newFile)
        {
            if (pieceColor.Equals("Light"))
            {
                if (!HasMoved)
                {
                    if(currentFile == newFile && currentRank + 1 == newRank && Board.ValidateSpace(currentRank + 1, currentFile) && !Board.GetBoardSpace(newRank,newFile).HasPiece())
                    {
                        return true;
                    }
                    else if (currentFile == newFile && currentRank + 2 == newRank && Board.ValidateSpace(currentRank +2, currentFile) && !Board.GetBoardSpace(newRank, newFile).HasPiece() && !Board.GetBoardSpace(newRank, newFile - 1).HasPiece())
                    {
                        return true;
                    }
                    else if (currentFile + 1 == newFile && currentRank + 1 == newRank && Board.ValidateSpace(currentRank + 1, currentFile +1) && Board.GetBoardSpace(currentRank +1, currentFile +1).HasPiece() && Board.GetBoardSpace(newRank,newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    else if (currentFile - 1 == newFile && currentRank - 1 == newRank && Board.ValidateSpace(currentRank - 1, currentFile - 1) && Board.GetBoardSpace(currentRank -1, currentFile -1).HasPiece() && Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    if (currentFile == newFile && currentRank + 1 == newRank && Board.ValidateSpace(currentRank +1, currentFile) && !Board.GetBoardSpace(newRank, newFile).HasPiece())
                    {
                        return true;
                    }
                    else if (currentFile + 1 == newFile && currentRank + 1 == newRank && Board.ValidateSpace(currentRank + 1, currentFile + 1) && Board.GetBoardSpace(currentRank +1, currentFile +1).HasPiece() && Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    else if (currentFile - 1 == newFile && currentRank - 1 == newRank && Board.ValidateSpace(currentRank - 1, currentFile - 1) && Board.GetBoardSpace(currentRank -1, currentFile -1).HasPiece() && Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (!HasMoved)
                {
                    if (currentFile == newFile && currentRank - 1 == newRank && Board.ValidateSpace(currentRank -1, currentFile) && !Board.GetBoardSpace(newRank, newFile).HasPiece())
                    {
                        return true;
                    }
                    else if (currentFile == newFile && currentRank - 2 == newRank && Board.ValidateSpace(currentRank -2, currentFile) && !Board.GetBoardSpace(newRank, newFile).HasPiece() && !Board.GetBoardSpace(newRank, newFile + 1).HasPiece())
                    {
                        return true;
                    }
                    else if (currentFile + 1 == newFile && currentRank + 1 == newRank && Board.ValidateSpace(currentRank + 1, currentFile + 1) && Board.GetBoardSpace(currentRank +1, currentFile +1).HasPiece() && Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    else if (currentFile - 1 == newFile && currentRank - 1 == newRank && Board.ValidateSpace(currentRank - 1, currentFile - 1) && Board.GetBoardSpace(currentRank -1, currentFile -1).HasPiece() && Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
                else
                {
                    if (currentFile == newFile && currentRank - 1 == newRank && Board.ValidateSpace(currentRank -1, currentFile) && !Board.GetBoardSpace(newRank, newFile).HasPiece())
                    {
                        return true;
                    }
                    else if (currentFile + 1 == newFile && currentRank + 1 == newRank && Board.ValidateSpace(currentRank + 1, currentFile + 1) && Board.GetBoardSpace(currentRank +1, currentFile +1).HasPiece() && Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                    else if (currentFile - 1 == newFile && currentRank - 1 == newRank && Board.ValidateSpace(currentRank - 1, currentFile - 1) && Board.GetBoardSpace(currentRank -1, currentFile -1).HasPiece() && Board.GetBoardSpace(newRank, newFile).GetPiece().GetColor() != this.GetColor())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public enum TypeOfPiece { King, Queen, Bishop, Knight, Rook, Pawn }
}