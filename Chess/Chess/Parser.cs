using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;

namespace Chess
{
    public class Parser
    { 
        ArrayList validLines;
        public static bool ReadFile(string fileName)
        {
            ArrayList validLines = new ArrayList();
            try {
                StreamReader inputReader = new StreamReader(fileName);
                while (!inputReader.EndOfStream)
                {
                    String line = inputReader.ReadLine();
                    if (ParseLine(line))
                    {
                        validLines.Add(line);
                    }
                }
                inputReader.Close();
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("There was an error.\n");
                Console.WriteLine(e.ToString());
                Console.WriteLine("\n");
                return false;
            }
            return true;
       }
        public static bool ParseLine(String line)
        {
            string placingPattern = "^([KQBNRP])([ld])([a-h, A-H][1-8])$";
            string movingPattern = "^([a-h,A-H][1-8])\\s([a-h,A-H][1-8])$";
            string doubleMovePattern = "^([a-h,A-H][1-8])\\s([a-h,A-H][1-8])\\s([a-h,A-H][1-8])\\s([a-h,A-H][1-8])$";

            if (Regex.IsMatch(line, placingPattern))
            {
                char piece = line.ElementAt(0);
                char color = line.ElementAt(1);
                char rank = line.ElementAt(2);
                char file = line.ElementAt(3);
                Piece p = new Piece(piece, color);
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
                char firstStartingFile = line.ElementAt(1);
                char firstEndingRank = line.ElementAt(3);
                char firstEndingFile = line.ElementAt(4);
                char secondStartingRank = line.ElementAt(6);
                char secondStartingFile = line.ElementAt(7);
                char secondEndingRank = line.ElementAt(9);
                char secondEndingFile = line.ElementAt(10);
                string message = string.Concat("Move the piece at ", firstStartingRank, firstStartingFile, " to ", firstEndingRank, firstEndingFile, " and the piece at ", secondStartingRank, secondStartingFile, " to ", secondEndingRank, secondEndingFile);
                PrintInfo(line, message);
            }
            else if (Regex.IsMatch(line, "^(\\S)"))
            {
                PrintInfo(line, "This line is bad input.");
                return false;
            }
            return true;
        }
        public static void PrintInfo(string line, string message)
        {
            Console.WriteLine(line + " " + message);
        }
        public void PrintBoard(Board chessboard)
        {
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (chessboard.getBoardSpace(i, j).GetPiece())
                    {
                        Console.WriteLine("|" + chessboard);
                    }
                    else
                    {
                        Console.WriteLine("|--");
                    }
                }
                Console.WriteLine("|");
            }
        }
        public ArrayList getValidLines()
        {
            return validLines;
        }
    }
}