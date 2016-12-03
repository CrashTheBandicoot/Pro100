using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Chess
{
    public class Game
    {
        private Board chessBoard;
        public Game()
        {
            chessBoard = new Board();
        }
        public void PlacePieces(ArrayList placements, ArrayList englishEquivalent)
        {
            for (int i = 0; i < placements.Count; i++)
            {
                char file = placements[i].ToString().ElementAt(2);
                int rank = int.Parse(placements[i].ToString().Substring(3,1))-1;
                
                int fileAsInt;
                switch (file)
                {
                    case 'a':
                        fileAsInt = 0;
                        break;
                    case 'b':
                        fileAsInt = 1;
                        break;
                    case 'c':
                        fileAsInt = 2;
                        break;
                    case 'd':
                        fileAsInt = 3;
                        break;
                    case 'e':
                        fileAsInt = 4;
                        break;
                    case 'f':
                        fileAsInt = 5;
                        break;
                    case 'g':
                        fileAsInt = 6;
                        break;
                    case 'h':
                        fileAsInt = 7;
                        break;
                    default:
                        fileAsInt = 0;
                        break;
                }
                //english here
                Parser.PrintInfo(placements[i].ToString(),englishEquivalent[i].ToString());
                chessBoard.SetPieces(rank, fileAsInt, placements[i].ToString().ElementAt(0), placements[i].ToString().ElementAt(1));
                Parser.PrintBoard();
            }
        }
        public void PlayGame(ArrayList moves, ArrayList englishEquivalent, int modifier)
        {
            for(int i = 0; i < moves.Count; i++)
            {
                if (chessBoard.Move(moves[i].ToString()))
                {
                    Parser.PrintInfo(moves[i].ToString(), englishEquivalent[i + modifier].ToString());
                }
                Parser.PrintBoard();
            }
        }
        public void PlayGame()
        {
            bool lightsTurn = true;
            while (true)
            {
                if (lightsTurn)
                {
                    Console.WriteLine("It is Light's Turn.");
                    string move = Console.ReadLine();
                    string message;
                    if (Parser.ParseLine(move, out message))
                    {
                        if (Board.GetBoardSpace(move[1] - '0' - 1, move[0] - 'a').GetPiece().GetColor().Equals("Light"))
                        {
                            if (chessBoard.Move(move))
                            {
                                if (!chessBoard.DetermainCheck("Light"))
                                {
                                    lightsTurn = false;
                                    Parser.PrintInfo(move, message);
                                    if (chessBoard.DetermainCheck("Dark"))
                                    {
                                        Console.WriteLine("The Dark king is in Check.");
                                    }
                                }
                                else
                                {
                                    string undoMove = move[3].ToString() + move[4].ToString() + move[2].ToString() + move[0].ToString() + move[1].ToString();
                                    chessBoard.Move(undoMove);
                                    message = "That places you in check.";
                                }
                            }
                            Parser.PrintBoard();
                        }
                        else
                        {
                            Console.WriteLine("That was not your piece.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("It is Dark's Turn.");
                    string move = Console.ReadLine();
                    string message;
                    if (Parser.ParseLine(move, out message))
                    {
                        if (Board.GetBoardSpace(move[1] - '0' - 1, move[0] - 'a').GetPiece().GetColor().Equals("Dark"))
                        {
                            if (chessBoard.Move(move))
                            {
                                if (!chessBoard.DetermainCheck("Light"))
                                {
                                    lightsTurn = true;
                                    Parser.PrintInfo(move, message);
                                    if (chessBoard.DetermainCheck("Light"))
                                    {
                                        Console.WriteLine("The Light king is in Check.");
                                    }
                                }
                                else
                                {
                                    string undoMove = move[3].ToString() + move[4].ToString() + move[2].ToString() + move[0].ToString() + move[1].ToString();
                                    chessBoard.Move(undoMove);
                                    message = "That places you in check.";
                                }
                                Parser.PrintBoard();
                            }
                            else
                            {
                                Console.WriteLine("That was not your piece.");
                            }
                        }
                    }
                }
            }
        }
        public void SquaresWithPieces()
        {
            for(int i = 0; i < Board.GetBoardSize(); i++)
            {
                for(int j = 0; j < Board.GetBoardSize(); j++)
                {
                    if (Board.GetBoardSpace(i,j).HasPiece())
                    {
                        Console.WriteLine(i + " " + j);
                    }
                }
            }
        }
        
    }
}