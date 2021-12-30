using System;

namespace FinalBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What type of game would you like to play?");
            Console.WriteLine("1 - Human vs Human");
            Console.WriteLine("2 - Human vs Computer");
            Console.WriteLine("3 - Computer vs Computer");

            int choice;

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("That is not a recognized command. Defaulting to Human vs Computer game.");
                choice = 2;
            }
            

            (PlayerType heroes, PlayerType monsters) = choice switch
            {
                1 => (PlayerType.Human, PlayerType.Human),
                2 => (PlayerType.Human, PlayerType.Computer),
                3 => (PlayerType.Computer, PlayerType.Computer),
                _ => (PlayerType.Human, PlayerType.Computer)
            };

            Game game = new Game(heroes, monsters);
            game.RunGame();
        }
    }
}
