using QueensPuzzle;
using System;
using System.Collections.Generic;

namespace EightQueensPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 8;

            // 注入size
            var queen = new Queen(size);

            var answer = queen.Search();

            Console.Write(answer);
            Console.ReadKey();
        }      
    }
}
