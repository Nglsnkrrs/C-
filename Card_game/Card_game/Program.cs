namespace Card_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("Игрок 1", "Игрок 2");
            game.Start();
        }
    }
}
