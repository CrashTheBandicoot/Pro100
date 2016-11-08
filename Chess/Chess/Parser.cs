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
            string myFile = "TestFiles\\SimpleTest.txt";
            string moveFile = "TestFiles\\MoveTests.txt";
            string placeFile = "TestFiles\\PlaceTests.txt";
            StreamReader inputReader = new StreamReader("TestFiles\\MoveTests.txt");
            while (!inputReader.EndOfStream)
            {
                String line = inputReader.ReadLine();
                 ParseLine(line);
            }
            inputReader.Close();
        }
        public static void ParseLine(String line)
        {
            string placingPattern = "([KQBNRP])([ld])([a-h, A-H][1-8])";
            string movingPattern = "([a-h,A-H][1-8])\\s([a-h,A-H][1-8])";
            string doubleMovePattern = "([a-h,A-H][1-8])\\s([a-h,A-H][1-8])\\s([a-h,A-H][1-8])\\s([a-h,A-H][1-8])";

            if (Regex.IsMatch(line, placingPattern))
            {
                Console.WriteLine(line);
            }
            else if (Regex.IsMatch(line, movingPattern))
            {
                Console.WriteLine(line);
            }
            else if (Regex.IsMatch(line, doubleMovePattern))
            {
                Console.WriteLine(line);
            }
        }
    }
}