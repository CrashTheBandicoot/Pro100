using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board
    {
        const int boardSize = 8;
        private static Space[,] boardSpaces;
        public Board()
        {
            string startingColor;
            string otherColor;
            string currentColor;
            boardSpaces = new Space[boardSize, boardSize];
            for(int i = 0; i < boardSize; i++)
            {
                if(i % 2 == 0)
                {
                    startingColor = "Black";
                    otherColor = "White";
                }
                else
                {
                    startingColor = "White";
                    otherColor = "Black";
                }
                for(int j = 0; j < boardSize; j++)
                {
                    currentColor = (j % 2 == 0) ? startingColor : otherColor;
                    boardSpaces[i, j] = new Space(currentColor);
                }
            }
        }
        public void SetPieces(int rank, int file, char pieceType, char pieceColor)
        {
            boardSpaces[rank, file].AddPiece(pieceType, pieceColor);
        }
        public static Space GetBoardSpace(int rank, int file)
        {
            return boardSpaces[rank,file];
        }
        public static bool ValidateSpace(int rank, int file)
        {
            return rank >= 0 && rank < boardSize && file >= 0 && file < boardSize; 
        }
        public bool Move(string movement)
        {
            //return to bool eventually
            /*
            piece.move() pass x and y for new space
            */
            if (movement.Length == 5)
            {
                int currentFile = CharToInt(movement[0]);
                int currentRank = int.Parse(movement[1].ToString())-1;
                int newFile =  CharToInt(movement[3]);
                int newRank = int.Parse(movement[4].ToString())-1;
                if (boardSpaces[currentRank, currentFile].HasPiece())
                {
                    Piece movingPiece = boardSpaces[currentRank, currentFile].GetPiece();
                    if(movingPiece.Move(movingPiece.GetPieceType(), currentRank, currentFile, newRank, newFile))
                    {
                        string pieceString = movingPiece.GetPieceString();
                        boardSpaces[newRank, newFile].AddPiece(pieceString[1], pieceString[0]);
                        boardSpaces[currentRank, currentFile].RemovePiece();
                        return true;
                    }
                    else
                    {
                        Parser.PrintInfo(movement, "This is an invalid move.\n");
                        return false;
                    }
                }
                else
                {
                    Parser.PrintInfo(movement, "The stating space does not contain a piece to move.\n");
                    return false;
                }
            }
            else
            {
                string firstMove = string.Concat(movement[0], movement[1], movement[3], movement[4]);
                string secondMove = string.Concat(movement[6], movement[7], movement[9], movement[10]);
                if(Move(firstMove) && Move(secondMove))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        private int CharToInt(char letter)
        {
            int numEquivalent = 0;
            switch (letter)
            {
                case 'a':
                    numEquivalent = 0;
                    break;
                case 'b':
                    numEquivalent = 1;
                    break;
                case 'c':
                    numEquivalent = 2;
                    break;
                case 'd':
                    numEquivalent = 3;
                    break;
                case 'e':
                    numEquivalent = 4;
                    break;
                case 'f':
                    numEquivalent = 5;
                    break;
                case 'g':
                    numEquivalent = 6;
                    break;
                case 'h':
                    numEquivalent = 7;
                    break;
            }
            return numEquivalent;
        }
        private char IntToChar(int number)
        {
            char charEquivalent = 'a';
            switch (number)
            {
                case 0:
                    charEquivalent = 'a';
                    break;
                case 1:
                    charEquivalent = 'b';
                    break;
                case 2:
                    charEquivalent = 'c';
                    break;
                case 3:
                    charEquivalent = 'd';
                    break;
                case 4:
                    charEquivalent = 'e';
                    break;
                case 5:
                    charEquivalent = 'f';
                    break;
                case 6:
                    charEquivalent = 'g';
                    break;
                case 7:
                    charEquivalent = 'h';
                    break;
            }
            return charEquivalent;
        }
        public static int GetBoardSize()
        {
            return boardSize;
        }
        public bool DetermainCheck(string colorOfKing)
        {
            for(int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    if(Board.GetBoardSpace(i,j).HasPiece() && boardSpaces[i,j].GetPiece().GetPieceType() == TypeOfPiece.King && boardSpaces[i,j].GetPiece().GetColor().Equals(colorOfKing))
                    {
                        for(int k = 0; k < boardSize; k++)
                        {
                            for (int l = 0; l < boardSize; l++)
                            {
                                if (boardSpaces[k,l].HasPiece() && !boardSpaces[k, l].GetPiece().GetColor().Equals(colorOfKing))
                                {
                                    Console.WriteLine(IntToChar(l).ToString() + (k + 1).ToString() + " " + IntToChar(j).ToString() + (i + 1).ToString());
                                    if (GetBoardSpace(k, l).GetPiece().Move(GetBoardSpace(k, l).GetPiece().GetPieceType(), l, (k + 1), j, (i + 1)))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        //public bool DetermainCheckMate(string colorOfKing)
        //{
        //    for (int i = 0; i < boardSize; i++)
        //    {
        //        for (int j = 0; j < boardSize; j++)
        //        {
        //            if (boardSpaces[i, j].GetPiece().GetPieceType() == TypeOfPiece.King && boardSpaces[i, j].GetPiece().GetColor() == colorOfKing)
        //            {
        //                if ()
        //                {

        //                }
        //                else
        //                {
        //                    for (int k = 0; k < boardSize; k++)
        //                    {
        //                        for (int l = 0; l < boardSize; l++)
        //                        {
        //                            if (boardSpaces[k, l].GetPiece().GetColor() == colorOfKing && Move(k.ToString() + l.ToString() + " " + i.ToString() + j.ToString()))
        //                            {

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}