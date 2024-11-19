using FantasyRPG;

namespace FantasyRPGIntegrationTesting;

[Category("Integration Tests")]
public class AHuman
{
    [Test]
    public void Has10PercentChanceOfInflictingDamage()
    {
        Human sut = new()
        {
            Strength = 30
        };
        int doubleDamageCount = 0;
        for (int i = 0; i < 20000; i++)
        {
            Damage damage = sut.InflictDamage();
            if (damage.Total == damage.Base * 2)
            {
                doubleDamageCount++;
            }
        }
        decimal percent = doubleDamageCount / 20000m;
        Assert.That(percent, Is.EqualTo(0.1m).Within(0.003));
    }
}
