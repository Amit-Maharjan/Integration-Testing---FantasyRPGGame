namespace FantasyRPG;

public class Demon : Creature
{
    public Demon()
    {
    }

    public Demon(IRandom random, Damage damage) : base(random, damage)
    {
    }

    public override string Race { get; protected set; } = "Demon";

    public override Damage InflictDamage()
    {
        _ = base.InflictDamage();
        // A demon has 25% chance of inflicting additional 10 damage
        if (_random.Get(1, 100) <= 25)
        {
            _damage.Additional = 10;
        }
        else
        {
            _damage.Additional = 0;
        }
        return _damage;
    }
}
