using FantasyRPG;
using NSubstitute;

namespace FantasyRPGUnitTesting;

[Category("Unit Tests")]
public class ABalrog
{
    [Test]
    public void ReportsItsRaceAsBalrog()
    {
        Creature sut = new Balrog();
        string race = sut.Race;
        Assert.That(race, Is.EqualTo("Balrog"));
    }

    [Test]
    public void CanInflictBaseDamageTwice()
    {
        IRandom mockRandom = Substitute.For<IRandom>();
        mockRandom.Get(1, 30).Returns(25);
        mockRandom.Get(1, 100).Returns(30); // 30% chance
        Damage mockDamage = Substitute.For<Damage>();
        Balrog sut = new(mockRandom, mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Base = 25;
        mockDamage.Received().Additional = 0;
        mockDamage.Received().Additional = 25;
    }

    [Test]
    public void CanInflictBaseDamageTwiceWithAdditional10Damage()
    {
        IRandom mockRandom = Substitute.For<IRandom>();
        mockRandom.Get(1, 30).Returns(25);
        mockRandom.Get(1, 100).Returns(25); // 25% chance
        Damage mockDamage = Substitute.For<Damage>();
        Balrog sut = new(mockRandom, mockDamage)
        {
            Strength = 30
        };
        sut.InflictDamage();
        mockDamage.Received().Base = 25;
        mockDamage.Received().Additional = 10;
        mockDamage.Received().Additional = 35;
    }
}
