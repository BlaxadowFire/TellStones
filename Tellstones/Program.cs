namespace Tellstones
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = Game.Instance;
            while(true)
            {
                game.Initialize();
                game.StartGame();
            }
        }
    }
}
