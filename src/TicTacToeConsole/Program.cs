using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char userSymbol = 'X';
            char systemSymbol = 'O';
            char[,] gameBoard = new char[3, 3];

            Console.Write($"You will be playing as X. ");
            Console.WriteLine($"The system will be playing as O.\n");

            DisplayGameBoard(gameBoard);

            Console.WriteLine("Choose a row and column to place your symbol.");



        }

        static void DisplayGameBoard(char[,] gameBoard)
        {
            Console.WriteLine("Current Game Board:");
            Console.WriteLine("   0  1  2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"[{gameBoard[i, j]}]");
                }
                Console.WriteLine();
            }
        }
    }
}
