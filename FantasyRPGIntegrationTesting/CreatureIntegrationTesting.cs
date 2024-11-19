using FantasyRPG;

namespace FantasyRPGIntegrationTesting;

[Category("Integration Tests")]
public class ACreature
{
    [Test]
    public void CanInflictBaseDamage()
    {
        Creature sut = new()
        {
            Strength = 30
        };

        for (int i = 0; i < 100; i++)
        {
            var actual = sut.InflictDamage();
            Assert.That(actual.Base, Is.InRange(1,30));
        }
    }

    [Test]
    public void Has99PercentChanceOfTakingDamage()
    {
        const decimal MAX = 10000;
        Creature sut = new()
        {
            Strength = 1,
            HitPoints = 100
        };
        int damageTakenCount = 0;
        for (int i = 0; i < MAX; ++i)
        {
            int damageTaken = sut.TakeDamage(1);
            if (damageTaken > 0)
            {
                damageTakenCount++;
            }
        }
        decimal percent = damageTakenCount / MAX;
        Assert.That(percent, Is.EqualTo(0.99).Within(0.002));
    }

    [Test]
    public void Has1PercentChanceOfNotTakingDamage()
    {
        const decimal MAX = 10000;
        Creature sut = new()
        {
            Strength = 1,
            HitPoints = 100
        };
        int noDamageTakenCount = 0;
        for (int i = 0; i < MAX; ++i)
        {
            int damageTaken = sut.TakeDamage(1);
            if (damageTaken == 0)
            {
                noDamageTakenCount++;
            }
        }
        decimal percent = noDamageTakenCount / MAX;
        Assert.That(percent, Is.EqualTo(0.01).Within(0.002));
    }
}
