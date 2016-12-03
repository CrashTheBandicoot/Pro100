using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace Chess
{
    public class Parser
    { 
        static ArrayList validPlacements = new ArrayList();
        static ArrayList englishEquivalent = new ArrayList();
        static ArrayList validMoves = new ArrayList();
        public static bool ReadFile(string fileName)
        {
            try {
                StreamReader inputReader = new StreamReader(fileName);
                while (!inputReader.EndOfStream)
                {
                    string line = inputReader.ReadLine();
                    string message;
                    if (ParseLine(line, out message))
                    {
                        englishEquivalent.Add(message);
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
        public static bool ParseLine(String line, out String message)
        {
            string placingPattern = "^([KQBNRP])([ld])([a-h, A-H][1-8])$";
            string movingPattern = "^([a-h,A-H][1-8])\\s([a-h,A-H][1-8])$";
            string doubleMovePattern = "^([a-h,A-H][1-8])\\s([a-h,A-H][1-8])\\s([a-h,A-H][1-8])\\s([a-h,A-H][1-8])$";

            message = "";
            if (Regex.IsMatch(line, placingPattern))
            {
                char piece = line.ElementAt(0);
                char color = line.ElementAt(1);
                char rank = line.ElementAt(2);
                char file = line.ElementAt(3);
                Piece p = new Piece(piece, color);
                message = string.Concat("Place the ", p.GetColor(), " ", p.GetPieceType(), " at ", rank, file, "\n");
                validPlacements.Add(line);
                return true;
            }
            else if (Regex.IsMatch(line, movingPattern))
            {
                char startingRank = line.ElementAt(0);
                char startingFile = line.ElementAt(1);
                char endingRank = line.ElementAt(3);
                char endingFile = line.ElementAt(4);
                message = string.Concat("Move the piece at ", startingRank, startingFile, " to ", endingRank, endingFile, "\n");
                validMoves.Add(line);
                return true;
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
                message = string.Concat("Move the piece at ", firstStartingRank, firstStartingFile, " to ", firstEndingRank, firstEndingFile, " and the piece at ", secondStartingRank, secondStartingFile, " to ", secondEndingRank, secondEndingFile,"\n");
                validMoves.Add(line);
                return true;
            }
            else if (!Regex.IsMatch(line, "^($)"))
            {
                PrintInfo(line, "This line is invalid input.");
                return false;
            }
            return false;
        }
        public static void PrintInfo(string line, string message)
        {
            Console.WriteLine(line + " " + message);
        }
        public static void PrintBoard()
        {
            Console.WriteLine("*|A |B |C |D |E |F |G |H |");
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    if(j == 0)
                    {
                        Console.Write(i + 1);
                    }
                    if (Board.GetBoardSpace(i,j).HasPiece())
                    {
                        Console.Write("|" + Board.GetBoardSpace(i,j).GetPiece().GetPieceString());
                    }
                    else
                    {
                        Console.Write("|--");
                    }
                }
                Console.Write("|\n");
            }
            Console.WriteLine("\n");
        }
        public ArrayList GetValidPlacements()
        {
            return validPlacements;
        }
        public ArrayList GetEnglishEquivalent()
        {
            return englishEquivalent;
        }
        public ArrayList GetValidMoves()
        {
            return validMoves;
        }
    }
}