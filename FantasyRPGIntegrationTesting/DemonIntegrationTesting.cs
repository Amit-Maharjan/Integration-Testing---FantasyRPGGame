using FantasyRPG;

namespace FantasyRPGIntegrationTesting;

[Category("Integration Tests")]
public class ADemon
{
    [Test]
    public void Has25PercentChanceOfInflictingAdditional10Damage()
    {
        Demon sut = new()
        {
            Strength = 30
        };
        int additional10DamageCount = 0;
        for (int i = 0; i < 200000; i++)
        {
            Damage damage = sut.InflictDamage();
            if (damage.Total == damage.Base + 10)
            {
                additional10DamageCount++;
            }
        }
        decimal percent = additional10DamageCount / 200000m;
        Assert.That(percent, Is.EqualTo(0.25m).Within(0.003));
    }

    [Test]
    public void Has75PercentChanceOfInflictingBaseDamage()
    {
        Demon sut = new()
        {
            Strength = 30
        };
        int baseDamageCount = 0;
        for (int i = 0; i < 200000; i++)
        {
            Damage damage = sut.InflictDamage();
            if (damage.Total == damage.Base)
            {
                baseDamageCount++;
            }
        }
        decimal percent = baseDamageCount / 200000m;
        Assert.That(percent, Is.EqualTo(0.75m).Within(0.003));
    }
}
