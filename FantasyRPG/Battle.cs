namespace FantasyRPG;

public class Battle
{
    public Message Message { get; } = new Message();

    public int Duel(Creature creature1, Creature creature2)
    {
        ArgumentNullException.ThrowIfNull(creature1, nameof(creature1));
        ArgumentNullException.ThrowIfNull(creature2, nameof(creature2));

        while (creature1.HitPoints >= 1 && creature2.HitPoints >= 1) {
            Message.Add($"The {creature1.Race} deals {creature1.Attack(creature2)} damage to the {creature2.Race}.");
            Message.Add($"The {creature2.Race} deals {creature2.Attack(creature1)} damage to the {creature1.Race}.");
        }

        if (creature1.HitPoints < 1 && creature2.HitPoints < 1)
        {
            Message.Add("The duel is a tie.");
            return 0;
        }
        else if (creature2.HitPoints < 1)
        {
            Message.Add($"The first Creature {creature1.Race} won the duel.");
            return 1;
        }
        else {
            Message.Add($"The second Creature {creature2.Race} won the duel.");
            return 2;
        }
    }
}
