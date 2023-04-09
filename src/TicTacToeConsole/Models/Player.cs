namespace TicTacToeConsole.src.Models
{
    public class Player
    {
        public bool IsUser { get; private set; }
        public char Symbol { get; private set; }


        // Constructor that initializes a Player object with the given 'isUser' and 'symbol' values.
        public Player(bool isUser, char symbol)
        {
            IsUser = isUser;
            Symbol = symbol;
        }
    }
}