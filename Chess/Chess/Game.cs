using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Game
    {
        private Board chessBoard;
        public Game()
        {
            chessBoard = new Board();
        }
        public void UpdateGame(string[] placements)
        {
            chessBoard.SetPieces(placements);
        }
    }
}