namespace FantasyRPG;

public class Balrog : Demon
{
    public Balrog()
    {
    }

    public Balrog(IRandom random, Damage damage) : base(random, damage)
    {
    }

    public override string Race { get; protected set; } = "Balrog";

    public override Damage InflictDamage()
    {
        _ = base.InflictDamage();
        _damage.Additional += _random.Get(1, Strength);
        return _damage;
    }
}
