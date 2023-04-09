namespace TicTacToeConsole.src.Models
{
    /*
     The Player class represents a player in the Tic Tac Toe game.
    */
    public class Player
    {
        /*
          Gets or sets the symbol representing the player in the game.
         */
        public bool IsUser { get; private set; }
        public char Symbol { get; private set; }


        /**
         * Initializes a new instance of the Player class with the given 'isUser' and 'symbol' values.
         * 
         * isUser: A boolean indicating whether the player is a user or not.
         * symbol: The symbol representing the player in the game.
         */
        public Player(bool isUser, char symbol)
        {
            IsUser = isUser;
            Symbol = symbol;
        }
    }
}