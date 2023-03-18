using System;
using TicTacToeConsole.src.Models;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();

                ConsoleHelper.PrintLine("Please choose your symbol (X or O):");
                char userSymbol = Console.ReadLine().ToUpper()[0];
                char systemSymbol = userSymbol == 'X' ? 'O' : 'X';

                Game game = new Game(userSymbol, systemSymbol);

                ConsoleHelper.PrintLine("Who goes first? (1) User (2) System");
                string firstMoveChoice = Console.ReadLine();
                bool userFirst = firstMoveChoice == "1";

                if (!userFirst)
                {
                    game.SystemMove();
                }

                while (game.State == GameState.Ongoing)
                {
                    Console.Clear();
                    ConsoleHelper.DisplayGameBoard(game.GameBoard);

                    ConsoleHelper.PrintLine("Your turn! Enter row (0, 1, or 2) and column (0, 1, or 2) separated by a space, or type 'exit' to quit: ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "exit")
                    {
                        Environment.Exit(0);
                    }

                    string[] inputParts = input.Split(' ');
                    int row = int.Parse(inputParts[0]);
                    int col = int.Parse(inputParts[1]);

                    if (game.UserMove(row, col))
                    {
                        game.State = game.CheckGameState();
                        if (game.State == GameState.Ongoing)
                        {
                            Console.Clear();
                            ConsoleHelper.DisplayGameBoard(game.GameBoard);
                            ConsoleHelper.PrintLine("System's turn:");
                            game.SystemMove();
                            game.State = game.CheckGameState();
                        }
                    }
                    else
                    {
                        ConsoleHelper.PrintLine("Invalid move. Try again.");
                    }
                }

                Console.Clear();
                ConsoleHelper.DisplayGameBoard(game.GameBoard);
                ConsoleHelper.PrintLine(game.State == GameState.UserWon ? "Congratulations! You won!" : game.State == GameState.SystemWon ? "System won!" : "It's a draw!");
                ConsoleHelper.PrintLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                ConsoleHelper.PrintLine("Welcome to Tic Tac Toe!");
                ConsoleHelper.PrintLine("1. Start game");
                ConsoleHelper.PrintLine("2. Exit");

                string menuChoice = Console.ReadLine();

                if (menuChoice == "1") return;
                else if (menuChoice == "2")
                {
                    Environment.Exit(0);
                }
                else
                {
                    ConsoleHelper.PrintLine("Invalid Input");
                }
            }
        }
    }
}

