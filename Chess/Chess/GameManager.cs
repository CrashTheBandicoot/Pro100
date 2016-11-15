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
            Console.BufferHeight = 20000;
            askinfForFile();
        }
        static void askinfForFile()
        {
            //string TestFile = "TestFiles\\SimpleTest.txt";
            Console.WriteLine("Please enter the .txt file you would like to use.");
            string fileName = Console.ReadLine();
            while (!Parser.ReadFile(fileName))
            {
                Console.WriteLine("That file does not exist in the Debug folder, please try again.");
                fileName = Console.ReadLine();
            }
        }
    }
}