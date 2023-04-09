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
                ConsoleHelper.PrintLine("Please choose your symbol (X or O):");
                char userSymbol = Console.ReadLine().ToUpper()[0];
                char systemSymbol = userSymbol == 'X' ? 'O' : 'X';

                gameInstance = new Game(userSymbol, systemSymbol);

                bool userExited = gameInstance.StartGame(); // Call the StartGame method and store the returned value

                if (userExited)
                {
                    break;
                }
            }
        }

    }

}

