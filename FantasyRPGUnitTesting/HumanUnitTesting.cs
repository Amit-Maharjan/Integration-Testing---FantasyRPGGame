using FantasyRPG;
using NSubstitute;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class AHuman
{
    [Test]
    public void ReportsItsRaceAsHuman()
    {
        Creature sut = new Human();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Human"));
    }

    [Test]
    public void Has10PercentChanceOfInflictingDoubleDamage()
    {
        int baseDamage = 25;
        IRandom mockRandom = Substitute.For<IRandom>();
        mockRandom.Get(1, 30).Returns(baseDamage); // Damage
        mockRandom.Get(1, 100).Returns(10); // 10% chance
        Damage mockDamage = Substitute.For<Damage>();
        Human sut = new(mockRandom, mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Additional = baseDamage;
    }
}
