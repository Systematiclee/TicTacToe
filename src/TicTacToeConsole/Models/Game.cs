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

    public class Game
    {
        public char[,] GameBoard { get; set; }
        public Player User { get; set; }
        public Player System { get; set; }
        public GameState State { get; set; }

        public Game(char userSymbol, char systemSymbol)
        {
            GameBoard = new char[3, 3];
            User = new Player(true, userSymbol);
            System = new Player(false, systemSymbol);
            State = GameState.Ongoing;
        }

        public bool UserMove(int row, int col)
        {
            if (GameBoard[row, col] == '\0')
            {
                GameBoard[row, col] = User.Symbol;
                return true;
            }
            return false;
        }

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

        private bool CheckWin(Player player)
        {
            char symbol = player.Symbol;

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (GameBoard[row, 0] == symbol && GameBoard[row, 1] == symbol && GameBoard[row, 2] == symbol)
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (GameBoard[0, col] == symbol && GameBoard[1, col] == symbol && GameBoard[2, col] == symbol)
                {
                    return true;
                }
            }

            // Check diagonals
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
    }
}

