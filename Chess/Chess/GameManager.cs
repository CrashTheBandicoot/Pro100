using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chess
{
    class GameManager
    {
        static void Main(string[] args)
        {
            Parser p = new Parser();
            if(args.Length > 0)
            {
                Parser.ReadFile(args[0]);
            }
            else
            {
                askingForFile();
            }
            Game chess = new Game();
            chess.PlacePieces(p.GetValidPlacements(),p.GetEnglishEquivalent());
            chess.PlayGame();
//            chess.PlayGame(p.GetValidMoves(),p.GetEnglishEquivalent(), p.GetValidPlacements().Count);
//            chess.SquaresWithPieces();
        }
        static void askingForFile()
        {
            //string TestFile = "SimpleTest.txt";
            Console.WriteLine("Please enter the .txt file you would like to use.");
            string fileName = Console.ReadLine();
            while (!Parser.ReadFile(fileName))
            {
                Console.WriteLine("The file " + fileName + " does not exist in the Debug folder, please try again.");
                fileName = Console.ReadLine();
            }
        }
    }
}