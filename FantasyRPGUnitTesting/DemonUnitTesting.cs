using FantasyRPG;
using NSubstitute;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class ADemon
{
    [Test]
    public void ReportsItsRaceAsDemon()
    {
        Creature sut = new Demon();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Demon"));
    }

    [Test]
    public void Has25PercentChanceOfInflictingAdditional10Damage()
    {
        int baseDamage = 25;
        IRandom mockRandom = Substitute.For<IRandom>();
        mockRandom.Get(1, 30).Returns(baseDamage); // Damage
        mockRandom.Get(1, 100).Returns(25); // 25% chance
        Damage mockDamage = Substitute.For<Damage>();
        Demon sut = new(mockRandom, mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Base = baseDamage;
        mockDamage.Received().Additional = 10;
    }

    [Test]
    public void Has75PercentChanceOfInflictingBaseDamage()
    {
        int baseDamage = 25;
        IRandom mockRandom = Substitute.For<IRandom>();
        mockRandom.Get(1, 30).Returns(baseDamage); // Damage
        mockRandom.Get(1, 100).Returns(30); // 30% chance
        Damage mockDamage = Substitute.For<Damage>();
        Demon sut = new(mockRandom, mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Base = baseDamage;
        mockDamage.Received().Additional = 0;
    }
}
