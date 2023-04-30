
// This file contains the entry point of the Tic Tac Toe console application
using System;
using TicTacToeConsole.src.Models;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Game gameInstance = null;

            while (Game.Menu()) // The loop will continue as long as the user wants to play
            {
                // The below code lets the user select which symbol they want to be 'X' or 'O'
                ConsoleHelper.PrintLine("Please choose your symbol (X or O):");
                char userSymbol = Console.ReadLine().ToUpper()[0];
                char systemSymbol = userSymbol == 'X' ? 'O' : 'X';

                gameInstance = new Game(userSymbol, systemSymbol);

                // Call the StartGame method and store the returned value
                bool userExited = gameInstance.StartGame(); 

                if (userExited)
                {
                    break;
                }
            }
        }

    }

}

