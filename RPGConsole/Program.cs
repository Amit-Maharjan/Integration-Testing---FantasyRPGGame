using FantasyRPG;

namespace RPGConsole;

internal class Program
{
    static void Main(string[] args)
    {
        int humanWin = 0;
        int balrogWin = 0;
        int gameTie = 0;
        
        for (int i = 1; i <= 100; i++) {
            Creature human = new Human()
            {
                Strength = 50,
                HitPoints = 100
            };

            Creature balrog = new Balrog()
            {
                Strength = 50,
                HitPoints = 100
            };

            Console.WriteLine($"Details of Game {i}:");
            Battle battle = new();
            int result = battle.Duel(human, balrog);
            battle.Message.Show();
            Console.WriteLine(Environment.NewLine);

            if (result == 0)
            {
                gameTie++;
            }
            else if (result == 1) { 
                humanWin++;
            } else
            {
                balrogWin++;
            }
        }

        Console.WriteLine($"Human won {humanWin} times out of 100 matches.");
        Console.WriteLine($"Balrog won {balrogWin} times out of 100 matches.");
        Console.WriteLine($"The game between Human and Balrog was tied {gameTie} times out of 100 matches.");
    }
}
