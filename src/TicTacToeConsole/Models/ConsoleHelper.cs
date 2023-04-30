/*
 * This file contains the ConsoleHelper class which provides helper methods for console input/output related to the game.
 */
using System;

namespace TicTacToeConsole.src.Models 
{
    /*
     * The ConsoleHelper class provides helper methods for console input/output related to the game.
     */
    public static class ConsoleHelper
    {
        // A method that displays the current game board in the console.
        // It takes a 2D char array representing the game board as a parameter.
        public static void DisplayGameBoard(Game game, char[,] gameBoard)
        {
            // Print user and system symbols
            PrintLine($"User: {game.User.Symbol} | System: {game.System.Symbol}");

            // Print column numbers
            PrintLine("  0   1   2");

            // Loop through each row of the game board.
            for (int row = 0; row < 3; row++)
            {
                // Print row number
                Print($"{row} ");

                // Loop through each column of the game board.
                for (int col = 0; col < 3; col++)
                {
                    // Get the value of the cell at the current row and column.
                    char cell = gameBoard[row, col];
                    Print(cell == '\0' ? " - " : $" {cell} ");

                    if (col < 2)
                    {
                        Print("|");
                    }
                }

                if (row < 2)
                {
                    PrintLine("\n  -----------");
                }
            }

            // Print an empty string to move the cursor to the next line.
            PrintLine("");
        }

        /// <summary>
        /// This method prints a message to the console without adding a new line at the end.
        /// </summary>
        /// <param name="message">The message to be printed.</param>
        private static void Print(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// This method prints a message to the console and adds a new line at the end.
        /// </summary>
        /// <param name="message">The message to be printed.</param>
        public static void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}