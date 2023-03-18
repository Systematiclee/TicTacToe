namespace TicTacToeConsole.src.Models
{
    public class Player
    {
        public bool IsUser { get; private set; }
        public char Symbol { get; private set; }

        public Player(bool isUser, char symbol)
        {
            IsUser = isUser;
            Symbol = symbol;
        }
    }
}