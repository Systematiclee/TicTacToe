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
            bool userTurn = false;
            bool exit = false;

            Menu();

            Print("Welcome to Tic Tac Toe!");


            PrintLine("Please select your preferred symbol (X or O): ");

            string symbolChoice = Console.ReadLine().ToUpper();

            userSymbol = symbolChoice == "O" ? 'O' : 'X';
            systemSymbol = symbolChoice == "O" ? 'X' : 'O';

            PrintLine($"You will be playing as {userSymbol}.");
            PrintLine($"The system will be playing as {systemSymbol}.");

            PrintLine("Select who goes first (1 for User, 2 for System): ");
            string firstChoice = Console.ReadLine();
            userTurn = firstChoice == "1";
            PrintLine($"{(userTurn ? "User" : "System")} goes first.");

            while (!exit)
            {
                Console.Clear();
                DisplayGameBoard(gameBoard, userSymbol, systemSymbol);

                if (userTurn)
                {
                    PrintLine("User's Turn:");
                    bool placedSymbol = false;
                    while (!placedSymbol)
                    {
                        PrintLine("Choose a row and column to place your symbol:");
                        Print("Enter row coordinate (0-2): ");
                        int row = int.Parse(Console.ReadLine());

                        Print("Enter column coordinate (0-2): ");
                        int col = int.Parse(Console.ReadLine());

                        placedSymbol = gameBoard[row, col] == '\0';
                        if (placedSymbol) gameBoard[row, col] = userSymbol;

                        DisplayGameBoard(gameBoard, userSymbol, systemSymbol);

                        if (!placedSymbol) PrintLine("That cell is already occupied. Please try again.");
                    }
                }
                else
                {
                    Console.Clear();
                    PrintLine("System's Turn:");

                    bool placedSymbol = false;
                    while (!placedSymbol)
                    {
                        Random rand = new Random();
                        int row = rand.Next(0, 3);
                        int col = rand.Next(0, 3);

                        if (gameBoard[row, col] == '\0')
                        {
                            gameBoard[row, col] = systemSymbol;
                            placedSymbol = true;
                        }
                    }

                    DisplayGameBoard(gameBoard, userSymbol, systemSymbol);
                }

                if (CheckWin(gameBoard, userSymbol))
                {
                    PrintLine("User wins!");
                    exit = true;
                }
                else if (CheckWin(gameBoard, systemSymbol))
                {
                    PrintLine("System wins!");
                    exit = true;
                }
                else if (CheckDraw(gameBoard))
                {
                    PrintLine("The game is a draw.");
                    exit = true;
                }
                userTurn = !userTurn;

                PrintLine("Enter 1 to continue playing or any other key to exit:");
                if (Console.ReadLine() != "1") exit = true;
            }

            PrintLine("Thanks for playing!");
        }

        private static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                PrintLine("Welcome to Tic Tac Toe!");
                PrintLine("1. Start game");
                PrintLine("2. Exit");

                string menuChoice = Console.ReadLine();

                if (menuChoice == "1") return;
                else if (menuChoice == "2")
                {
                    Environment.Exit(0);
                }
                else
                {
                    PrintLine("Invalid Input");
                }   
            }
        }

        private static void DisplayGameBoard(char[,] gameBoard, char userSymbol, char systemSymbol)
        {
            int rowLength = gameBoard.GetLength(0);
            int colLength = gameBoard.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    char symbol = gameBoard[i, j] == '\0' ? '-' : gameBoard[i, j];

                    if (symbol == userSymbol || symbol == systemSymbol)
                    {
                        Print($" {symbol} ");
                    }
                    else
                    {
                        Print($" {symbol} ");
                    }

                    Print(j < colLength - 1 ? "|" : "");
                }

                PrintLine("");
                PrintLine(i < rowLength - 1 ? "-----------" : "");
            }
        }

        private static bool CheckWin(char[,] gameBoard, char symbol)
        {
            // Check rows, columns and diagonals
            for (int i = 0; i < 3; i++)
            {
                if ((gameBoard[i, 0] == symbol && gameBoard[i, 1] == symbol && gameBoard[i, 2] == symbol) ||
                    (gameBoard[0, i] == symbol && gameBoard[1, i] == symbol && gameBoard[2, i] == symbol) ||
                    (gameBoard[0, 0] == symbol && gameBoard[1, 1] == symbol && gameBoard[2, 2] == symbol) ||
                    (gameBoard[0, 2] == symbol && gameBoard[1, 1] == symbol && gameBoard[2, 0] == symbol))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckDraw(char[,] gameBoard)
        {
            // Check if all cells in the board are occupied
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == '\0')
                    {
                        return false;
                    }
                }
            }

            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 0] != '\0' && gameBoard[i, 1] != '\0' && gameBoard[i, 2] != '\0' &&
                    (gameBoard[i, 0] != gameBoard[i, 1] || gameBoard[i, 1] != gameBoard[i, 2]) &&
                    (gameBoard[0, i] != gameBoard[1, i] || gameBoard[1, i] != gameBoard[2, i]))
                {
                    return false;
                }
            }

            // Check diagonals
            if ((gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2]) ||
                (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0]))
            {
                return false;
            }

            // If none of the above conditions are met, the game is a draw
            return true;
        }

        private static void Print(string message)
        {
            Console.Write(message);
        }

        private static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        
    }
}