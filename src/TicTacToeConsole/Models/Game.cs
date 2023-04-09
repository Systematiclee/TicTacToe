/*
 * This file defines the Game class and the GameState enum.
 * The Game class provides the core logic for the game and manages the game state.
 * The GameState enum represents the possible states of the game.
 */

using System;


namespace TicTacToeConsole.src.Models
{
    public enum GameState 
    {
        Ongoing,
        Draw,
        UserWon,
        SystemWon
    }

    /*
     * The Game class provides the core logic for the game and manages the game state.
     * It defines the properties and methods needed to play the game.
     */
    public class Game
    {
        // Properties of the game
        public char[,] GameBoard { get; set; }
        public Player User { get; set; }
        public Player System { get; set; }
        public GameState State { get; set; }

        public int UserWins { get; private set; }
        public int SystemWins { get; private set; }
        public int Draws { get; private set; }
        public DateTime GameStartTime { get; private set; }

        // Constructor of the game
        public Game(char userSymbol, char systemSymbol)
        {
            GameBoard = new char[3, 3];
            User = new Player(true, userSymbol);
            System = new Player(false, systemSymbol);
            State = GameState.Ongoing;
            UserWins = 0;
            SystemWins = 0;
            Draws = 0;
        }

        // Shutdown method that displays statistics and run-time statistics
        public void Shutdown()
        {
            DisplayStatistics();
            DisplayRunTimeStatistics();
        }
        public bool StartGame()
        {
            ResetGame(); // Reset the game board and state

            // Start the timer
            GameStartTime = DateTime.Now;

            // Determine who goes first
            ConsoleHelper.PrintLine("Who goes first? (1) User (2) System");
            string firstMoveChoice = Console.ReadLine();
            bool userFirst = firstMoveChoice == "1";

            if (!userFirst)
            {
                SystemMove();
            }

            bool userExited = false;

            // Game loop
            while (State == GameState.Ongoing)
            {
                Console.Clear();
                ConsoleHelper.DisplayGameBoard(this, GameBoard);

                ConsoleHelper.PrintLine("Your turn! Enter row (0, 1, or 2) and column (0, 1, or 2) separated by a space, or type 'exit' to quit: ");
                string input = Console.ReadLine();

                // Exit if the user types "exit"
                if (input.ToLower() == "exit")
                {
                    userExited = true;
                    break;
                }

                // Parse the user's input
                string[] inputParts = input.Split(' ');
                int row = int.Parse(inputParts[0]);
                int col = int.Parse(inputParts[1]);

                if (UserMove(row, col))
                {
                    State = CheckGameState();

                    // If the game is still ongoing, make the system's move
                    if (State == GameState.Ongoing)
                    {
                        Console.Clear();
                        ConsoleHelper.DisplayGameBoard(this, GameBoard);
                        ConsoleHelper.PrintLine("System's turn:");
                        SystemMove();
                        State = CheckGameState();
                    }
                }
                else
                {
                    ConsoleHelper.PrintLine("Invalid move. Try again.");
                }
            }

            // Game over
            if (!userExited)
            {
                Console.Clear();
                ConsoleHelper.DisplayGameBoard(this, GameBoard);
                ConsoleHelper.PrintLine(State == GameState.UserWon ? "Congratulations! You won!" : State == GameState.SystemWon ? "System won!" : "It's a draw!");
                ConsoleHelper.PrintLine("Press any key to continue...");
                Console.ReadKey();
            }

            // Update game statistics after the game ends
            if (State == GameState.UserWon) UserWins++;
            else if (State == GameState.SystemWon) SystemWins++;
            else if (State == GameState.Draw) Draws++;

            return userExited;
        }

        //Resets the board when a new game is started
        public void ResetGame()
        {
            GameBoard = new char[3, 3];
            State = GameState.Ongoing;
        }

        // Logic for the users move
        public bool UserMove(int row, int col)
        {
            if (GameBoard[row, col] == '\0')
            {
                GameBoard[row, col] = User.Symbol;
                return true;
            }
            return false;
        }

        //Logic for the systems move
        public void SystemMove()
        {
            bool placedSymbol = false;
            while (!placedSymbol)
            {
                Random rand = new Random();
                int row = rand.Next(0, 3);
                int col = rand.Next(0, 3);

                if (GameBoard[row, col] == '\0')
                {
                    GameBoard[row, col] = System.Symbol;
                    placedSymbol = true;
                    ConsoleHelper.PrintLine($"System plays: Row:{row} and Column:{col}");
                }
            }
        }

        
        public GameState CheckGameState()
        {
            if (CheckWin(User))
            {
                return GameState.UserWon;
            }
            else if (CheckWin(System))
            {
                return GameState.SystemWon;
            }
            else if (CheckDraw())
            {
                return GameState.Draw;
            }
            else
            {
                return GameState.Ongoing;
            }
        }

        // Logic for Checking for wins
        private bool CheckWin(Player player)
        {
            char symbol = player.Symbol;

            // Checks rows for win
            for (int row = 0; row < 3; row++)
            {
                if (GameBoard[row, 0] == symbol && GameBoard[row, 1] == symbol && GameBoard[row, 2] == symbol)
                {
                    return true;
                }
            }

            // Checks columns for win
            for (int col = 0; col < 3; col++)
            {
                if (GameBoard[0, col] == symbol && GameBoard[1, col] == symbol && GameBoard[2, col] == symbol)
                {
                    return true;
                }
            }

            // Checks diagonals for win
            if (GameBoard[0, 0] == symbol && GameBoard[1, 1] == symbol && GameBoard[2, 2] == symbol)
            {
                return true;
            }

            if (GameBoard[0, 2] == symbol && GameBoard[1, 1] == symbol && GameBoard[2, 0] == symbol)
            {
                return true;
            }

            return false;
        }

        // Checking if the game is a draw
        private bool CheckDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (GameBoard[row, col] == '\0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Logic for displaying the games statistics
        public void DisplayStatistics()
        {
            ConsoleHelper.PrintLine("Game Statistics:");
            if (UserWins + SystemWins + Draws == 0)
            {
                ConsoleHelper.PrintLine("No games played yet.");
            }
            else
            {
                ConsoleHelper.PrintLine($"User wins: {UserWins}");
                ConsoleHelper.PrintLine($"System wins: {SystemWins}");
                ConsoleHelper.PrintLine($"Draws: {Draws}");
            }
        }

        // logic for displaying time played
        public void DisplayRunTimeStatistics()
        {
            int totalGames = UserWins + SystemWins + Draws;
            TimeSpan totalTimePlayed = DateTime.Now - GameStartTime;
            long averageTimePerGameTicks = totalGames > 0 ? totalTimePlayed.Ticks / totalGames : 0;
            TimeSpan averageTimePerGame = TimeSpan.FromTicks(averageTimePerGameTicks);

            ConsoleHelper.PrintLine("Run-Time Statistics:");
            ConsoleHelper.PrintLine($"Total time played: {totalTimePlayed}");
            ConsoleHelper.PrintLine($"Average time per game: {averageTimePerGame}");
        }

        // Main menu of the game
        public static bool Menu()
        {
            Game game = null; // create a variable to hold the game instance

            while (true)
            {
                Console.Clear();
                ConsoleHelper.PrintLine("Welcome to Tic Tac Toe!");
                ConsoleHelper.PrintLine("1. Start game");
                ConsoleHelper.PrintLine("2. Shutdown and show play statistics");

                string menuChoice = Console.ReadLine();

                if (menuChoice == "1")
                {
                    // create a new instance of the game if one does not exist
                    if (game == null)
                    {
                        ConsoleHelper.PrintLine("Please choose your symbol (X or O):");
                        char userSymbol = Console.ReadLine().ToUpper()[0];
                        char systemSymbol = userSymbol == 'X' ? 'O' : 'X';
                        game = new Game(userSymbol, systemSymbol);
                    }

                    bool userExited = game.StartGame(); // Call the StartGame method and store the returned value
                }
                else if (menuChoice == "2")
                {
                    // display statistics and run-time statistics only if games have been played
                    if (game != null && (game.UserWins + game.SystemWins + game.Draws) > 0)
                    {
                        game.DisplayStatistics();
                        game.DisplayRunTimeStatistics();
                    }

                    ConsoleHelper.PrintLine("Press any key to exit...");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    ConsoleHelper.PrintLine("Invalid Input");
                }
            }
        }



    }
}

