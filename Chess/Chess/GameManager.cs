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
            Parser.ReadFile();
        }
    }
}