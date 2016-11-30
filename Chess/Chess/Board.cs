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
        private Space[,] boardSpaces;
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
        public void SetPieces(string[] placements)
        {
            for (int i = 0; i < placements.Length; i++)
            {
                char file = placements[i].ElementAt(2);
                int rank = placements[i].ElementAt(3);
                int fileAsInt;
                switch (file)
                {
                    case 'A':
                        fileAsInt = 0;
                        break;
                    case 'B':
                        fileAsInt = 1;
                        break;
                    case 'C':
                        fileAsInt = 2;
                        break;
                    case 'D':
                        fileAsInt = 3;
                        break;
                    case 'E':
                        fileAsInt = 4;
                        break;
                    case 'F':
                        fileAsInt = 5;
                        break;
                    case 'G':
                        fileAsInt = 6;
                        break;
                    case 'H':
                        fileAsInt = 7;
                        break;
                    default:
                        fileAsInt = 0;
                        break;
                }
                boardSpaces[rank, fileAsInt].AddPiece(placements[i].ElementAt(0), placements[i].ElementAt(1));
              }
            }
        public Space getBoardSpace(int file, int rank)
        {
            return boardSpaces[rank,file];
        }
    }
}