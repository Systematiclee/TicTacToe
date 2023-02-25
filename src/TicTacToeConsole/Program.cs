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

            Console.WriteLine("You will be playing as X.");
            Console.WriteLine("The system will be playing as O.\n");

            DisplayGameBoard(gameBoard, userSymbol, systemSymbol);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Game Menu:");
                Console.WriteLine("1. Place your symbol");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice (1-2): ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Choose a row and column to place your symbol:");
                    Console.Write("Enter row coordinate (0-2): ");
                    int row = int.Parse(Console.ReadLine());

                    Console.Write("Enter column coordinate (0-2): ");
                    int col = int.Parse(Console.ReadLine());

                    if (gameBoard[row, col] != '\0')
                    {
                        Console.WriteLine("That cell is already occupied. Please try again.");
                        continue;
                    }

                    gameBoard[row, col] = userSymbol;
                    DisplayGameBoard(gameBoard, userSymbol, systemSymbol);
                }
                else if (input == "2")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void DisplayGameBoard(char[,] gameBoard, char userSymbol, char systemSymbol)
        {
            Console.WriteLine("Current Game Board:");
            Console.WriteLine("   0  1  2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == userSymbol)
                    {
                        Console.Write($"[{userSymbol}]");
                    }
                    else if (gameBoard[i, j] == systemSymbol)
                    {
                        Console.Write($"[{systemSymbol}]");
                    }
                    else
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}





