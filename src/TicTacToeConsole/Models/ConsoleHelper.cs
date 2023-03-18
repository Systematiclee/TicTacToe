using System;

namespace TicTacToeConsole.src.Models 
{
    public static class ConsoleHelper
    {

        public static void DisplayGameBoard(char[,] gameBoard)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    char cell = gameBoard[row, col];
                    Console.Write(cell == '\0' ? " - " : $" {cell} ");

                    if (col < 2)
                    {
                        Console.Write("|");
                    }
                }

                if (row < 2)
                {
                    Console.WriteLine("\n-----------");
                }
            }

            Console.WriteLine();
        }
        public static void Print(string message)
        {
            Console.Write(message);
        }

        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}