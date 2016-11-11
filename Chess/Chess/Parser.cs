using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Chess
{
    public static class Parser
    {
        public static void ReadFile()
        {
            string TestFile = "TestFiles\\SimpleTest.txt";
            StreamReader inputReader = new StreamReader(TestFile);
            while (!inputReader.EndOfStream)
            {
                String line = inputReader.ReadLine();
                 ParseLine(line);
            }
            inputReader.Close();
        }
        public static void ParseLine(String line)
        {
            string placingPattern = "^([KQBNRP])([ld])([a-h, A-H][1-8])$";
            string movingPattern = "^([a-h,A-H][1-8])\\s([a-h,A-H][1-8])$";
            string doubleMovePattern = "^([a-h,A-H][1-8])\\s([a-h,A-H][1-8])\\s([a-h,A-H][1-8])\\s([a-h,A-H][1-8])$";

            if (Regex.IsMatch(line, placingPattern))
            {
                char piece = line.ElementAt(0);
                char color = line.ElementAt(1);
                char file = line.ElementAt(3);
                char rank = line.ElementAt(2);
                string pieceColor;
                if (color.Equals('l'))
                {
                    pieceColor = "light";
                }
                else
                {
                    pieceColor = "dark";
                }
                Piece p = new Piece(piece, pieceColor);
                string message = string.Concat("Place the ", p.GetColor(), " ", p.GetPieceType(), " at ", rank, file);
                PrintInfo(line, message);
            }
            else if (Regex.IsMatch(line, movingPattern))
            {
                char startingRank = line.ElementAt(0);
                char startingFile = line.ElementAt(1);
                char endingRank = line.ElementAt(3);
                char endingFile = line.ElementAt(4);
                string message = string.Concat("Move the piece at ", startingRank, startingFile, " to ", endingRank, endingFile);
                PrintInfo(line, message);
            }
            else if (Regex.IsMatch(line, doubleMovePattern))
            {
                char firstStartingRank = line.ElementAt(0);
                char firstStartingFile= line.ElementAt(1);
                char firstEndingRank = line.ElementAt(3);
                char firstEndingFile = line.ElementAt(4);
                char secondStartingRank = line.ElementAt(6);
                char secondStartingFile = line.ElementAt(7);
                char secondEndingRank = line.ElementAt(9);
                char secondEndingFile = line.ElementAt(10);
                string message = string.Concat("Move the piece at ", firstStartingRank, firstStartingFile, " to ", firstEndingRank, firstEndingFile, " and the piece at ", secondStartingRank, secondStartingFile, " to ", secondEndingRank, secondEndingFile);
                PrintInfo(line, message);
            }
        }
        public static void PrintInfo(string line, string message)
        {
            Console.WriteLine(line + " " + message);
        }
    }
}