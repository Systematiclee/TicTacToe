namespace TicTacToeConsole.src.Models
{
    /*
     The Player struct represents a player in the Tic Tac Toe game.
     It is a lightweight value type that can be used for representing 
     simple objects that have no identity.
    */
    public struct Player
    {
        /*
          Gets the symbol representing the player in the game.
         */
        public char Symbol { get; }
        

        /**
         * Initializes a new instance of the Player struct with the given 'isUser' and 'symbol' values.
         * 
         * isUser: A boolean indicating whether the player is a user or not.
         * symbol: The symbol representing the player in the game.
         */

        public Player(bool isUser, char symbol)
        {
            // Set the Symbol property of the struct
            
            Symbol = symbol;
        }
    }
}